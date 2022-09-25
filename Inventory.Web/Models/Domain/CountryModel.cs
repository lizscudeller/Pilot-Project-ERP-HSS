using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Data.Entity;

namespace Inventory.Web.Models
{
    #region Attribute
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Countries.Count();
            }
            return ret;
        }

        public static List<CountryModel> RescueList(int page = 0, int lenPage = 0, string filter = "", string order = "")
        {
            var ret = new List<CountryModel>();

            using (var db = new ContextBD())
            {
              
                    var filterWhere = "";
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filterWhere = string.Format(" where lower(name) like '%{0}%'", filter.ToLower());
                    }

                    var pos = (page - 1) * lenPage;
                    var pagination = "";
                    if (page > 0 && lenPage > 0)
                    {
                        pagination = string.Format(" offset {0} rows fetch next {1} rows only", 
                        pos, lenPage);
                    }

                    var sql = 
                        "select *" +
                        " from country" +
                        filterWhere +
                        " order by " + (!string.IsNullOrEmpty(order) ? order : "name")  + 
                        pagination;


                ret = db.Database.Connection.Query<CountryModel>(sql).ToList();

            }
            return ret;
        }



        public static CountryModel IdRescue(int id)
        {
            CountryModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Countries.Find(id);
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
                    var country = new CountryModel { Id = id };
                    db.Countries.Attach(country);
                    db.Entry(country).State = EntityState.Deleted;
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
                    db.Countries.Add(this);
                }
                else
                {
                    db.Countries.Attach(this);
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