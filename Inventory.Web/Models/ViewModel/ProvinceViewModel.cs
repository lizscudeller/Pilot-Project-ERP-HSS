using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class ProvinceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill Name")]
        [MaxLength(30, ErrorMessage = "Name must have maximum of 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill Province Code")]
        [MaxLength(3, ErrorMessage = "Province Code must have maximum of 2 characters")]
        public string ProvinceCode { get; set; }
        public bool Active { get; set; }

        [Required(ErrorMessage = "Select Country")]
        public int IdCountry { get; set; }

    }
}