using Inventory.Web.Models;
using Rotativa;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]
    public class ReportResupplyController : Controller
    {
        [HttpGet]
        public ActionResult Filter()
        {
            return View("~/Views/Report/FilterReportResupplyView.cshtml");
        }
        [HttpPost]
        public ActionResult ValidateFilter(int? minimum)
        {
            var ok = true;
            var message = "";
            if ((minimum ?? 0) <= 0)
            {
                ok = false;
                message = "Fill the minimum quantity for each product.";
            }
            return Json(new { ok, message });
        }
        [HttpGet]
        public ActionResult Index(int minimum)
        {
            if (minimum == 0)
            {
                return RedirectToAction("Filter");
            }
            var storage = ProductModel.RescueReportResupply(minimum);

            return new ViewAsPdf("~/Views/Report/ReportResupplyView.cshtml", storage);
        }
    }
}