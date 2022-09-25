using Inventory.Web.Models;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]

    public class OperProductEntryController : OperEntryOutputProductController
    {
        protected override string SaveOrder(EntryOutputProductViewModel data)
        {
            var username = User.Identity.Name;
            return ProductModel.SaveOrderEntry(data.Date, data.Products, data.IdProvider, username);
        }
    }
}