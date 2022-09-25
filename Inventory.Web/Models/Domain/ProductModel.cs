using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Data.Entity;
using System.Linq;

namespace Inventory.Web.Models
{
    public class ProductModel
    {
        #region Attribute
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public decimal CostValue { get; set; }
        public decimal Price { get; set; }
        public int StorageQuant { get; set; }
        public int IdUnitMeasure { get; set; }
        public virtual UnitMeasureModel UnitMeasure { get; set; }
        public int IdGroup { get; set; }
        public virtual GroupProductModel Group { get; set; }
        public int IdBrand { get; set; }
        public virtual ProductBrandModel Brand { get; set; }
        public int IdProvider { get; set; }
        public virtual ProviderModel Provider { get; set; }
        public int IdStorageLocation { get; set; }
        public virtual StorageLocationModel StorageLocation { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; }

        #endregion

        #region Methods
        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Products.Count();

            }
            return ret;
        }


        public static List<ProductModel> RescueList(int page = 0, int lenPage = 0, string filter = "", string order = "", bool onlyActives = false)
        {
            var ret = new List<ProductModel>();

            using (var db = new ContextBD())
            {


                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" where lower(name) like '%{0}%'", filter.ToLower());
                }

                if (onlyActives)
                {
                    filterWhere = (string.IsNullOrEmpty(filterWhere) ? " where" : " and") + "(active = 1)";
                }

                var pos = (page - 1) * lenPage;
                var pagination = "";
                if (page > 0 && lenPage > 0)
                {
                    pagination = string.Format(" offset {0} rows fetch next {1} rows only",
                        pos > 0 ? pos - 1 : 0, lenPage);
                }


                var sql =
                      "select id, code, name, active, image, cost_value as CostValue, price as Price, " +
                      "storage_quant as StorageQuant, id_unit_measure as IsUnitMeasure, id_group as IdGroup, " +
                      "id_brand as IdBrand, id_provider as IdProvider, id_storage_location as IdStorageLocation " +
                      "from product " +
                      filterWhere +
                      "order by " + (!string.IsNullOrEmpty(order) ? order : "name") +
                      pagination;

                ret = db.Database.Connection.Query<ProductModel>(sql).ToList();

            }
            return ret;
        }



        public static ProductModel IdRescue(int id)
        {
            ProductModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Products.Find(id);
            }
            return ret;
        }

        public static string RescueImageId(int id)
        {
            string ret = "";

            using (var db = new ContextBD())
            {
                ret = db.Products
                     .Where(x => x.Id == id)
                     .Select(x => x.Image)
                     .SingleOrDefault();
            }
            return ret;

        }

        public static List<ReportStockPositionViewModel> RescueReportStockPosition()
        {
            var ret = new List<ReportStockPositionViewModel>();

            using (var db = new ContextBD())
            {
                ret = db.Products
                    .Where(x => x.Active)
                    .OrderBy(x => x.Name)
                    .Select(x => new ReportStockPositionViewModel()
                    {
                        CodeProduct = x.Code,
                        NameProduct = x.Name,
                        QuantityProduct = x.StorageQuant
                    }).ToList();
            }
            return ret;
        }

        public static List<ReportProductEntryViewModel> RescueReportProductEntry()
        {
            var ret = new List<ReportProductEntryViewModel>();

            using (var db = new ContextBD())
            {
                ret = db.EntriesProducts
                    .OrderBy(x => x.Date)
                    .Select(x => new ReportProductEntryViewModel()
                    {
                        Date = x.Date,
                        EntryNumber = x.Number,
                        NameProduct = x.Product.Name,
                        NameProvider = x.Provider.Name,
                        QuantityProduct = x.Quantity,
                        UserName = x.UserName
                    }).ToList();
            }
            return ret;
        }
        public static List<ReportResupplyViewModel> RescueReportResupply(int minimum)
        {
            var ret = new List<ReportResupplyViewModel>();

            using(var db = new ContextBD())
            {
                ret = db.Products
                    .Where(x => x.Active && x.StorageQuant < minimum)
                    .OrderBy(x => x.StorageQuant)
                    .ThenBy(x => x.Name)
                    .Select(x => new ReportResupplyViewModel()
                    {
                        CodeProduct = x.Code,
                        NameProduct = x.Name,
                        QuantityProduct = x.StorageQuant,
                        Purchase = (minimum - x.StorageQuant)
                    }).ToList();
            }
            return ret;
        }

        public static List<ReportProductLossViewModel> RescueReportLossProduct()
        {
            var ret = new List<ReportProductLossViewModel>();

            using (var db = new ContextBD())
            {
                ret = db.InventoriesStocks
                    .OrderBy(x => x.Date)
                    .Select(x => new ReportProductLossViewModel()
                    {
                        Date = x.Date,
                        CodeProduct = x.Product.Code,
                        NameProduct = x.Product.Name,
                        QuantityProduct = x.StorageQuantity,
                        Count = x.QuantityInventory,
                        Reason = x.Reason

                    }).ToList();
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
                    var product = new ProductModel { Id = id };
                    db.Products.Attach(product);
                    db.Entry(product).State = EntityState.Deleted;
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

                    db.Products.Add(this);
                }
                else
                {
                    db.Products.Attach(this);
                    db.Entry(this).State = EntityState.Modified;

                }
                db.SaveChanges();
                ret = this.Id;

            }
            return ret;
        }

        public static string SaveOrderEntry(DateTime date, Dictionary<int, int> products, int provider, string username)
        {
            return SaveOrder(date, products, provider, username, "entry_product", true);

        }

        public static string SaveOrderOutput(DateTime date, Dictionary<int, int> products, int provider, string username)
        {
            return SaveOrder(date, products, provider, username, "product_output", false);

        }

        public static string SaveOrder(DateTime date, Dictionary<int, int> products, int provider, string username, string tableName, bool entry)
        {
            var ret = "";
            try
            {
                using (var db = new ContextBD())
                {
                    db.Database.Connection.Open();

                    var numOrder = db.Database.Connection.ExecuteScalar<int>($"select next value for sec_{tableName}").ToString("D10");
                    

                    using (var transaction = db.Database.Connection.BeginTransaction())
                    {
                        foreach (var product in products)
                        {

                            var sql = $"insert into {tableName} (number, date, id_product, quant, id_provider, user_name) values (@number, @date, @id_product, @quant, @id_provider, @user_name)";
                            var parametesInsert = new { number = numOrder, date, id_product = product.Key, quant = product.Value, id_provider = provider, user_name = username };

                            db.Database.Connection.Execute(sql, parametesInsert, transaction);


                            var signal = (entry ? "+" : "-");
                            sql = $"update product set storage_quant = storage_quant {signal} @storage_quant where (id = @id)";
                            var parametesUpdate = new { id = product.Key, storage_quant = product.Value, id_provider = provider, user_name = username };

                            db.Database.Connection.Execute(sql, parametesUpdate, transaction);


                        }

                        transaction.Commit();

                        ret = numOrder;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return ret;

        }



        //public static string SaveOrderOut(DateTime date, Dictionary<int, int> products, string tableName, bool entry)
        //{
        //    var ret = "";
        //    try
        //    {
        //        using (var db = new ContextBD())
        //        {
        //            db.Database.Connection.Open();

        //            var numOrder = db.Database.Connection.ExecuteScalar<int>($"select next value for sec_{tableName}").ToString("D10");

        //            using (var transaction = db.Database.Connection.BeginTransaction())
        //            {
        //                foreach (var product in products)
        //                {

        //                    var sql = $"insert into {tableName} (number, date, id_product, quant) values (@number, @date, @id_product, @quant)";
        //                    var parametesInsert = new { number = numOrder, date, id_product = product.Key, quant = product.Value };

        //                    db.Database.Connection.Execute(sql, parametesInsert, transaction);


        //                    var signal = (entry ? "+" : "-");
        //                    sql = $"update product set storage_quant = storage_quant {signal} @storage_quant where (id = @id)";
        //                    var parametesUpdate = new { id = product.Key, storage_quant = product.Value };

        //                    db.Database.Connection.Execute(sql, parametesUpdate, transaction);


        //                }

        //                transaction.Commit();

        //                ret = numOrder;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return ret;

        //}
        public static List<ProductInventoryViewModel> RescueListForInventory()
        {
            var ret = new List<ProductInventoryViewModel>();

            using (var db = new ContextBD())
            {
                var sql =
                    "select " +
                    "p.id, p.code, p.name as NameProduct, p.storage_quant as StorageQuant, " +
                    "l.name as NameStorageLocation, u.name as NameUnitMeasure " +
                    "from product p, storage_location l, unit_measure u " +
                    "where (p.active = 1) and " +
                    "(p.id_storage_location =  l.id) and " +
                    "(p.id_unit_measure = u.id) " +
                    "order by l.name, p.name";

                ret = db.Database.Connection.Query<ProductInventoryViewModel>(sql).ToList();

            }


            return ret;
        }

        public static bool SaveInventory(List<ItemInventoryViewModel> data)
        {
            var ret = true;

            try
            {
                var date = DateTime.Now;

                using (var db = new ContextBD())
                {

                    foreach (var productInventory in data)
                    {
                        db.InventoriesStocks.Add(new InventoryStockModel
                        {
                            Date = date,
                            IdProduct = productInventory.IdProduct,
                            StorageQuantity = productInventory.StorageQuantity,
                            QuantityInventory = productInventory.QuantityInventory,
                            Reason = productInventory.Reason

                        });

                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static List<InventoryWithDifferenceViewModel> RescueListInventoryWithDifference()
        {

            var ret = new List<InventoryWithDifferenceViewModel>();

            using (var db = new ContextBD())
            {
                var data = db.InventoriesStocks
                    .Where(x => x.StorageQuantity > x.QuantityInventory)
                    .OrderBy(x => x.Date)
                    .GroupBy(x => new
                    {
                        Year = x.Date.Year,
                        Month = x.Date.Month,
                        Day = x.Date.Day,
                        x.Product.IdStorageLocation,
                        NameStorageLocation = x.Product.StorageLocation.Name
                    })
                    .Select(g => new
                    {
                        g.Key.Year,
                        g.Key.Month,
                        g.Key.Day,
                        g.Key.IdStorageLocation,
                        g.Key.NameStorageLocation
                    })
                    .ToList();

                foreach (var item in data)
                {
                    var date = new DateTime(item.Year, item.Month, item.Day);
                    ret.Add(new InventoryWithDifferenceViewModel
                    {
                        Id = $"{date.ToString("dd/MM/yyyy")},{item.IdStorageLocation}",
                        Name = $"{date.ToString("dd/MM/yyyy")} - {item.NameStorageLocation}"

                    });
                }
            }

            return ret;
        }

        public static List<ProductWithInventoryDifferenceViewModel> RescueProductListWithInventoryDifference(string inventory)
        {
            var ret = new List<ProductWithInventoryDifferenceViewModel>();

            var date = DateTime.ParseExact(inventory.Split(',')[0], "dd/MM/yyyy", null);
            var idLocal = Int32.Parse(inventory.Split(',')[1]);

            using (var db = new ContextBD())
            {
                ret = db.InventoriesStocks
                        .Where(x => DbFunctions.TruncateTime(x.Date) == date)
                        .Where(x => x.Product.IdStorageLocation == idLocal)
                        .Where(x => x.StorageQuantity > x.QuantityInventory)
                        .Select(x => new ProductWithInventoryDifferenceViewModel
                        {
                            Id = x.Id,
                            NameProduct = x.Product.Name,
                            CodeProduct = x.Product.Code,
                            StorageQuantity = x.StorageQuantity,
                            QuantityInventory = x.QuantityInventory,
                            Reason = x.Reason
                        }).ToList();
            }

            return ret;
        }


        public static bool SaveProductLoss(List<ProductLossViewModel> data)
        {
            var ret = true;

            try
            {
                using (var db  = new ContextBD())
                {
                    foreach (var entry in data)
                    {
                        var inventory = db.InventoriesStocks.Find(entry.Id);
                        inventory.Reason = entry.Reason;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                ret = false;
            }
            return ret;
        }

        public static List<dynamic> MonthlyLost(int month, int year)
        {
            var ret = new List<dynamic>();

            using (var db = new ContextBD())
            {
                ret = db.InventoriesStocks
                    .Where(x => x.Date.Month == month && x.Date.Year == year && x.StorageQuantity > x.QuantityInventory)
                    .Select(x => new { Day = x.Date.Day, Quant = x.StorageQuantity - x.QuantityInventory })
                    .ToList<dynamic>();
            }

            return ret;
        }


        #endregion


    }
}