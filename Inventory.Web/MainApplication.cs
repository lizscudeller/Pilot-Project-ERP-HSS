using Inventory.Web.Models;
using System.Security.Principal;

namespace Inventory.Web
{
    public class MainApplication : GenericPrincipal
    {
        public UserModel Data { get; set; }

        public MainApplication(IIdentity identity, string[] roles, int id) : base(identity, roles)
        {
            Data = UserModel.IdRescue(id);
        }
    }
}