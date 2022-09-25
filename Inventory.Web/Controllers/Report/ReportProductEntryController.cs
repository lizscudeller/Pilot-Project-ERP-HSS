using Inventory.Web.Models;
using Rotativa;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]
    public class ReportProductEntryController : Controller
    {
        public ActionResult Index()
        {
            var stock = ProductModel.RescueReportProductEntry();
            return new ViewAsPdf("~/Views/Report/ReportProductEntryView.cshtml", stock);
        }
    }
}