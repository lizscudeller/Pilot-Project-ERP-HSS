using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        [MaxLength(10, ErrorMessage = "Code field must be 10 characters max.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Field Name Required.")]
        [MaxLength(50, ErrorMessage = "Name field must be 50 characters max.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Cost Value Required.")]
        public decimal CostValue { get; set; }

        [Required(ErrorMessage = "Field Price Required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Field Storage Quantity Required.")]
        public int StorageQuant { get; set; }

        [Required(ErrorMessage = "Select Unit Measure.")]
        public int IdUnitMeasure { get; set; }


        [Required(ErrorMessage = "Select Group.")]
        public int IdGroup { get; set; }


        [Required(ErrorMessage = "Select Brand.")]
        public int IdBrand { get; set; }


        [Required(ErrorMessage = "Select Provider.")]
        public int IdProvider { get; set; }


        [Required(ErrorMessage = "Select Storage Location.")]
        public int IdStorageLocation { get; set; }

        public bool Active { get; set; }

        public string Image { get; set; }

    }
}