using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class ChangeUserPasswordViewModel
    {
        [Required(ErrorMessage = "Type your current password")]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Type your new password")]
        [MinLength(3, ErrorMessage = "The new password must to be at least 3 characters")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password")]
        [Compare("NewPassword",ErrorMessage = "The new password and confirmation must to be the same")]
        [Display(Name = "Confirm new password")]
        public string ConfirmNewPassword { get; set; }


    }
}