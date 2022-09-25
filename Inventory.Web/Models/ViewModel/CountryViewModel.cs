using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class CountryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name Required.")]
        [MaxLength(30, ErrorMessage = "The name must be less than 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "International code Required.")]
        [MaxLength(3, ErrorMessage = "The international code must be 3 characters.")]
        public string Code { get; set; }


        public bool Active { get; set; }

    }
}