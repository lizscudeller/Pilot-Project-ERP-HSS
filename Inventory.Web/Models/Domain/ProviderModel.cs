using System.Collections.Generic;
using System.Data.Entity;
using Dapper;
using System.Linq;

namespace Inventory.Web.Models
{
    public class ProviderModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string DocNum { get; set; }
        public TypePerson Type { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Instruction { get; set; }
        public string PostalCode { get; set; }
        public int IdCountry { get; set; }
        public virtual CountryModel Country { get; set; }
        public int IdProvince { get; set; }
        public virtual ProvinceModel Province { get; set; }
        public int IdCity { get; set; }
        public virtual CityModel City { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Providers.Count();
            }
            return ret;
        }

        public static List<ProviderModel> RescueList(int page, int lenPage, string filter = "", string order = "")
        {
            var ret = new List<ProviderModel>();

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
                        "select id, name, type, phone, contact, address, number, instruction, postal_code, active, " +
                        "corporate_name as CorporateName, doc_num as DocNum, id_country as IdCountry, " +
                        "id_province as IdProvince, id_city as IdCity" +
                        " from provider" +
                        filterWhere +
                        " order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                    pagination;

                ret = db.Database.Connection.Query<ProviderModel>(sql).ToList();
            }
            return ret;
        }



        public static ProviderModel IdRescue(int id)
        {
            ProviderModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Providers.Find(id);
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
                    var provider = new ProviderModel { Id = id };
                    db.Providers.Attach(provider);
                    db.Entry(provider).State = EntityState.Deleted;
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
                    db.Providers.Add(this);
                    }
                    else
                    {
                    db.Providers.Attach(this);
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