using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;

namespace Inventory.Web.Models
{
    public class GroupProductModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.GroupsProducts.Count();
            }
            return ret;
        }

        public static List<GroupProductModel> RescueList(int page, int lenPage, string filter = "", string order = "")
        {
            var ret = new List<GroupProductModel>();

            using (var db = new ContextBD())
            {
                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" where lower(name) like '%{0}%'", filter.ToLower());
                }

                var pos = (page - 1) * lenPage;

                var sql = string.Format(
                                        "select *" +
                                        " from product_group" +
                                        filterWhere +
                                        " order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                                        " offset {0} rows fetch next {1} rows only",
                                    pos, lenPage);
                ret = db.Database.Connection.Query<GroupProductModel>(sql).ToList();

            }
            return ret;
        }

        public static GroupProductModel IdRescue(int id)
        {
            GroupProductModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.GroupsProducts.Find(id);
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
                    var group = new GroupProductModel { Id = id };
                    db.GroupsProducts.Attach(group);
                    db.Entry(group).State = EntityState.Deleted;
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
                    db.GroupsProducts.Add(this);
                }
                else
                {
                    db.GroupsProducts.Attach(this);
                    db.Entry(this).State = EntityState.Modified;
                }

                db.SaveChanges();
                ret = this.Id;
            }
            return ret;
        }
        #endregion
    }
}
