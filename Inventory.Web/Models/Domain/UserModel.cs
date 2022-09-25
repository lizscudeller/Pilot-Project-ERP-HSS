using Inventory.Web.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data.Entity;

namespace Inventory.Web.Models
{
    public class UserModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<RoleModel> Roles { get; set; }

        #endregion

        #region Methods
        public static UserModel ValidateUser(string login, string password)
        {
            UserModel ret = null;
            password = CriptoHelper.HashMD5(password);

            using (var db = new ContextBD())
            {
                ret = db.Users
                     .Include(x => x.Roles)
                     .Where(x => x.Login == login && x.Password == password)
                     .SingleOrDefault();
            }
            return ret;
        }

        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Users.Count();
            }
            return ret;
        }


        public static List<UserModel> RescueList(int page = -1, int lenPage = -1, string filter = "", string order = "")
        {
            var ret = new List<UserModel>();

            using (var db = new ContextBD())
            {
                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" where lower(name) like '%{0}%'", filter.ToLower());
                }

                string sql;
                if (page == -1 || lenPage == -1)
                {
                    sql =
                    "select *" +
                    "from users" +
                    filterWhere +
                    " order by " + (!string.IsNullOrEmpty(order) ? order : "name");
                }
                else
                {
                    var pos = (page - 1) * lenPage;

                    sql = string.Format(
                    "select *" +
                    " from users " +
                    filterWhere +
                    " order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                    " offset {0} rows fetch next {1} rows only",
                    pos, lenPage);
                }

                ret = db.Database.Connection.Query<UserModel>(sql).ToList();

            }
            return ret;
        }
        public static UserModel IdRescue(int id)
        {
            UserModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Users.Find(id);
            }
            return ret;
        }

        public static UserModel RescueLogin(string login)
        {
            UserModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Users
                     .Where(x => x.Login == login)
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
                    var user = new UserModel { Id = id };
                    db.Users.Attach(user);
                    db.Entry(user).State = EntityState.Deleted;
                    db.SaveChanges();
                    ret = true;
                }
            }
            return ret;
        }

        public int Savee()
        {
            var ret = 0;

            var model = IdRescue(this.Id);

            using (var db = new ContextBD())
            {

                if (model == null)
                {
                    if (!string.IsNullOrEmpty(this.Password))
                    {
                        this.Password = CriptoHelper.HashMD5(this.Password);
                    }
                    db.Users.Add(this);
                }
                else
                {
                    db.Users.Attach(this);
                    db.Entry(this).State = EntityState.Modified;

                    if (string.IsNullOrEmpty(this.Password))
                    {
                        db.Entry(this).Property(x => x.Password).IsModified = false;
                    }
                    else
                    {
                        this.Password = CriptoHelper.HashMD5(this.Password);
                    }

                }
                db.SaveChanges();
                ret = this.Id;
            }
            return ret;
        }

        public string RescueStringNameRoles()
        {
            var ret = string.Empty;

            if (this.Roles != null && this.Roles.Count > 0)
            {
                var roles = this.Roles.Select(x => x.Name);
                ret = string.Join(";", roles);
            }

            return ret;
        }

        internal bool ValidateCurrentPassword(string currentPassword)
        {
            var ret = false;
            using (var db = new ContextBD())
            {
                this.Password = CriptoHelper.HashMD5(currentPassword);

                ret = db.Users
                     .Where(x => x.Password == Password && x.Id == this.Id)
                     .Any();
            }

            return ret;
        }

        public bool ChangePassword(string newPassword)
        {
            var ret = false;

            using (var db = new ContextBD())
            {
                this.Password = CriptoHelper.HashMD5(newPassword);
                db.Users.Attach(this);
                db.Entry(this).Property(x => x.Password).IsModified = true;
                db.SaveChanges();
                ret = true;
            }

            return ret;
        }
        #endregion
    }
}