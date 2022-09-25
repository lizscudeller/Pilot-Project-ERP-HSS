namespace Inventory.Web.Models
{
    public class ProductInventoryViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameProduct { get; set; }
        public string NameStorageLocation { get; set; }
        public int StorageQuant { get; set; }
        public string NameUnitMeasure { get; set; }

    }
}