using Inventory.Web.Models;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]

    public class OperProductOutputController : OperEntryOutputProductController
    {
        protected override string SaveOrder(EntryOutputProductViewModel data)
        {
            var username = User.Identity.Name;
            return ProductModel.SaveOrderOutput(data.Date, data.Products, data.IdProvider, username);

        }       
    }
}