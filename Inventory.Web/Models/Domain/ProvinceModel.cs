using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;

namespace Inventory.Web.Models
{
    public class ProvinceModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProvinceCode { get; set; }
        public bool Active { get; set; }
        public int IdCountry { get; set; }
        public virtual CountryModel Country { get; set; }
        #endregion

        #region Methods

        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Provinces.Count();
            }
            return ret;
        }

        public static List<ProvinceModel> RescueList(int page = 0, int lenPage = 0, string filter = "", string order = "", int idCountry = 0)
        {
            var ret = new List<ProvinceModel>();

            using (var db = new ContextBD())
            {
                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" where lower(name) like '%{0}%'", filter.ToLower());
                }


                if (idCountry > 0)
                {
                    filterWhere +=
                        (string.IsNullOrEmpty(filterWhere) ? " where" : " and") +
                        string.Format(" id_country = {0}", idCountry);
                }

                var pos = (page - 1) * lenPage;

                var pagination = "";
                if (page > 0 && lenPage > 0)
                {
                    pagination = string.Format(" offset {0} rows fetch next {1} rows only",
                    pos, lenPage);
                }


                var sql =
                    "select id, name, pcode as ProvinceCode, active, id_country as IdCountry" +
                    " from province" +
                    filterWhere +
                    " order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                    pagination;

                ret = db.Database.Connection.Query<ProvinceModel>(sql).ToList();
            }
            return ret;
        }



        public static ProvinceModel IdRescue(int id)
        {
            ProvinceModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Provinces.Find(id);
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
                    var province = new ProvinceModel { Id = id };
                    db.Provinces.Attach(province);
                    db.Entry(province).State = EntityState.Deleted;
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
                    db.Provinces.Add(this);
                }
                else
                {
                    db.Provinces.Attach(this);
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