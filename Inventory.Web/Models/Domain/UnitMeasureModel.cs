using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.Entity;

namespace Inventory.Web.Models
{
    public class UnitMeasureModel
    {
        #region Attribute
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.UnitsMeasures.Count();
            }
            return ret;
        }

        public static List<UnitMeasureModel> RescueList(int page, int lenPage, string filter = "", string order = "")
        {
            var ret = new List<UnitMeasureModel>();

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
                        " from unit_measure" +
                        filterWhere +
                        " order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                        " offset {0} rows fetch next {1} rows only",
                    pos, lenPage);

                ret = db.Database.Connection.Query<UnitMeasureModel>(sql).ToList();

            }
            return ret;
        }



        public static UnitMeasureModel IdRescue(int id)
        {
            UnitMeasureModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.UnitsMeasures.Find(id);
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
                    var unitMeasure = new UnitMeasureModel { Id = id };
                    db.UnitsMeasures.Attach(unitMeasure);
                    db.Entry(unitMeasure).State = EntityState.Deleted;
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
                    db.UnitsMeasures.Add(this);
                }
                else
                {
                    db.UnitsMeasures.Attach(this);
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