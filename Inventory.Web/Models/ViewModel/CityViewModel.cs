using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill Name")]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters")]
        public string Name { get; set; }
        public bool Active { get; set; }

        [Required(ErrorMessage = "Select Country")]
        public int IdCountry { get; set; }

        [Required(ErrorMessage = "Select Province")]
        public int IdProvince { get; set; }

        public string NameCountry { get; set; }
        public string NameProvince { get; set; }
    }
}