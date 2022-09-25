namespace Inventory.Web.Models
{
    public class ProductWithInventoryDifferenceViewModel
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string CodeProduct { get; set; }
        public int StorageQuantity { get; set; }
        public int QuantityInventory { get; set; }
        public string Reason { get; set; }

    }
}