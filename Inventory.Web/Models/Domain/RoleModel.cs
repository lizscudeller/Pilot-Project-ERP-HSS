using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Data.Entity;
using System.Linq;

namespace Inventory.Web.Models
{
    public class RoleModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual List<UserModel> Users { get; set; }

        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.RolesUsers.Count();
            }
            return ret;
        }

        public static List<RoleModel> RescueList(int page, int lenPage, string filter = "", string order = "")
        {
            var ret = new List<RoleModel>();

            using (var db = new ContextBD())
            {
                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" where lower(name) like '%{0}%'", filter.ToLower());
                }

                var pos = (page - 1) * lenPage;

                var sql = string.Format(
                    "select * " +
                    "from role " +
                    filterWhere +
                    "order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                    " offset {0} rows fetch next {1} rows only",
                pos, lenPage);

                ret = db.Database.Connection.Query<RoleModel>(sql).ToList();

            }
            return ret;
        }
        public static List<RoleModel> RescueListActives()
        {
            var ret = new List<RoleModel>();

            using (var db = new ContextBD())
            {
                ret = db.RolesUsers
                      .Where(x => x.Active)
                      .OrderBy(x => x.Name)
                      .ToList();
            }
            return ret;
        }

        public static RoleModel IdRescue(int id)
        {
            RoleModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.RolesUsers
                    .Include(x => x.Users)
                    .Where(x => x.Id == id)
                    .SingleOrDefault();
            }
            return ret;
        }
       
        public static bool IdDelete(int id)
        {
            var ret = false;

            if (IdRescue(id) != null)
            {

                using (var db = new ContextBD())
                {
                    var role = new RoleModel { Id = id };
                    db.RolesUsers.Attach(role);
                    db.Entry(role).State = EntityState.Deleted;
                    db.SaveChanges();
                    ret = true;
                }
            }
            return ret;
        }

        public int Savee()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                var model = db.RolesUsers
                     .Include(x => x.Users)
                     .Where(x => x.Id == this.Id)
                     .SingleOrDefault();

                if (model == null)
                {

                    if (this.Users != null && this.Users.Count > 0)
                    {
                        foreach (var user in this.Users)
                        {
                            db.Users.Attach(user);
                            db.Entry(user).State = EntityState.Unchanged;
                        }
                    }
                    db.RolesUsers.Add(this);
                }
                else
                {
                    model.Name = this.Name;
                    model.Active = this.Active;

                    if (this.Users != null)
                    {
                        foreach (var user in model.Users.FindAll(x => !this.Users.Exists(u => u.Id == x.Id)))
                        {
                            model.Users.Remove(user);
                        }

                        foreach (var user in this.Users.FindAll(x => x.Id > 0 && !model.Users.Exists(u => u.Id == x.Id)))
                        {
                            db.Users.Attach(user);
                            db.Entry(user).State = EntityState.Unchanged;
                            model.Users.Add(user);
                        }
                    }
                }
                db.SaveChanges();
                ret = this.Id;
            }
                                         
            return ret;
        }
        public void LoadUsers()
        {
            this.Users.Clear();
            using (var conection = new SqlConnection())
            {
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
                conection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conection;
                    command.CommandText =
                        "select u.* " +
                        "from role_users ru, users u " +
                        "where (ru.id_role = @id_role) and (ru.id_users = u.id)";

                    command.Parameters.Add("id_role", SqlDbType.Int).Value = this.Id;

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Users.Add(new UserModel
                        {
                            Id = (int)reader["id"],
                            Name = (string)reader["name"],
                            Login = (string)reader["login"]
                        });
                    }
                }
            }
        }
        #endregion

    }
}