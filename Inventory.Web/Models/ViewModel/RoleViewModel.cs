using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name Required.")]
        public string Name { get; set; }

        public bool Active { get; set; }

        public virtual List<UserViewModel> Users { get; set; }

        public RoleViewModel()
        {
            this.Users = new List<UserViewModel>();
        }

    }
}