using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class UnitMeasureViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Initials Required.")]
        public string Initials { get; set; }


        public bool Active { get; set; }

    }
}