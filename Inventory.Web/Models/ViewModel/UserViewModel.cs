using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please, enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter email")]
        public string Email { get; set; }

    }
}