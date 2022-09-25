
using Inventory.Web.Models;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]

    public abstract class OperEntryOutputProductController : BaseController
    {
        public ActionResult Index()
        {

            ViewBag.Products = ProductModel.RescueList(onlyActives: true);
            ViewBag.Providers = ProviderModel.RescueList(0,0,"","");

            return View();
        }

        protected abstract string SaveOrder(EntryOutputProductViewModel data);

        public JsonResult Save([ModelBinder(typeof(EntryOutputProductViewModelModelBinder))] EntryOutputProductViewModel data)
        {
            
            var numOrder = SaveOrder(data);
            var ok = (numOrder != "");

            return Json(new { OK = ok, Number = numOrder });
        }
    }
}