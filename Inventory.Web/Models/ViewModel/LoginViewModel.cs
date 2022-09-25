using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Inventory.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter User")]
        [Display(Name = "User:")]
        public string User { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Password:")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}