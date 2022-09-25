using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class GroupProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name Required.")]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
