using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.Entity;

namespace Inventory.Web.Models
{
    public class ProductBrandModel
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
                ret = db.ProductsBrands.Count();
            }
            return ret;
        }

        public static List<ProductBrandModel> RescueList(int page, int lenPage, string filter = "", string order = "")
        {
            var ret = new List<ProductBrandModel>();

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
                    " from product_brand" +
                    filterWhere +
                    " order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                    " offset {0} rows fetch next {1} rows only",
                    pos, lenPage);

                    ret = db.Database.Connection.Query<ProductBrandModel>(sql).ToList();

            }
            return ret;
        }



        public static ProductBrandModel IdRescue(int id)
        {
            ProductBrandModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.ProductsBrands.Find(id);
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
                    var brands = new ProductBrandModel { Id = id };
                    db.ProductsBrands.Attach(brands);
                    db.Entry(brands).State = EntityState.Deleted;
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
                    db.ProductsBrands.Add(this);

                }
                else
                {
                    db.ProductsBrands.Attach(this);
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