using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.Entity;
using System.Linq;

namespace Inventory.Web.Models
{
    public class CityModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int IdProvince { get; set; }

        public virtual ProvinceModel Province { get; set; }
        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Cities.Count();
            }
            return ret;
        }

        public static List<CityViewModel> RescueList(int page = 0, int lenPage = 0, string filter = "", string order = "", int idProvince = 0)
        {
            var ret = new List<CityViewModel>();

            using (var db = new ContextBD())
            {
                var pos = (page - 1) * lenPage;

                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" (lower(c.name) like '%{0}%') and", filter.ToLower());
                }

                if (idProvince > 0)
                {
                    filterWhere += string.Format(" (id_province = {0}) and", idProvince);
                }

                var pagination = "";
                if (page > 0 && lenPage > 0)
                {
                    pagination = string.Format(" offset {0} rows fetch next {1} rows only",
                    pos, lenPage);
                }

                var sql =
                    "select c.id, c.name, c.active, c.id_province as IdProvince, e.id_country as IdCountry," +
                    " e.name as NameProvince, p.name as NameCountry" +
                    " from city c, province e, country p" +
                    " where" +
                    filterWhere +
                    " (c.id_province = e.id) and" +
                    " (e.id_country = p.id)" +
                    " order by " + (!string.IsNullOrEmpty(order) ? order : "c.name") +
                    pagination;

                ret = db.Database.Connection.Query<CityViewModel>(sql).ToList();
            }
            return ret;
        }

        public static CityViewModel IdRescue(int id)
        {
            CityViewModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Cities
                    .Include(x => x.Province)
                    .Where(x => x.Id == id)
                    .Select(x => new CityViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Active = x.Active,
                        IdProvince = x.IdProvince,
                        IdCountry = x.Province.IdCountry,
                        NameProvince = x.Province.Name,
                        NameCountry = x.Province.Country.Name
                    })
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
                    var city = new CityModel { Id = id };
                    db.Cities.Attach(city);
                    db.Entry(city).State = EntityState.Deleted;
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
                    db.Cities.Add(this);
                }
                else
                {
                    db.Cities.Attach(this);
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