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
    public class StorageLocationModel
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
                ret = db.StoragesLocations.Count();
            }
            return ret;
        }

        public static List<StorageLocationModel> RescueList(int page, int lenPage, string filter = "", string order = "")
        {
            var ret = new List<StorageLocationModel>();

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
                         "from storage_location " +
                         filterWhere +
                         " order by  " + (!string.IsNullOrEmpty(order) ? order : "name") +
                         " offset {0} rows fetch next {1} rows only",
                     pos, lenPage);

                ret = db.Database.Connection.Query<StorageLocationModel>(sql).ToList();
            }
            return ret;
        }



        public static StorageLocationModel IdRescue(int id)
        {
            StorageLocationModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.StoragesLocations.Find(id);
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
                    var local = new StorageLocationModel { Id = id };
                    db.StoragesLocations.Attach(local);
                    db.Entry(local).State = EntityState.Deleted;
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
                    db.StoragesLocations.Add(this);
                }
                else
                {
                    db.StoragesLocations.Attach(this);
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