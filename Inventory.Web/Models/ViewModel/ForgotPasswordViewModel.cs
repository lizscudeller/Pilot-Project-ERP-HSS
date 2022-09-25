using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Enter Login")]
        public string Login { get; set; }
    }
}