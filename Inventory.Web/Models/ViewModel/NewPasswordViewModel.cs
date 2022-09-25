using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class NewPasswordViewModel
    {
        [Required(ErrorMessage = "Type password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }

        public int Users { get; set; }
    }
}