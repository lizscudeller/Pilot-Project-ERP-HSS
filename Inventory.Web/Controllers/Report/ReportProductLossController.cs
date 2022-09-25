using Inventory.Web.Models;
using Rotativa;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]
    public class ReportProductLossController : Controller
    {
        public ActionResult Index()
        {
            var stock = ProductModel.RescueReportLossProduct();
            return new ViewAsPdf("~/Views/Report/ReportProductLossView.cshtml", stock);
        }
    }
}