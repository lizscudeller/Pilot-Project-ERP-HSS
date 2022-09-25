namespace Inventory.Web.Models
{
    public class ItemInventoryViewModel
    {
        public int IdProduct { get; set; }
        public int StorageQuantity { get; set; }
        public int QuantityInventory { get; set; }
        public string Reason { get; set; }

    }
}