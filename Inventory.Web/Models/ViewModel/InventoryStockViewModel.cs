using System;

namespace Inventory.Web.Models
{
    public class InventoryStockViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public int StorageQuantity { get; set; }
        public int QuantityInventory { get; set; }
        public int IdProduct { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}