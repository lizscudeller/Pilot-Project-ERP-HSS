using Inventory.Web.Models;
using Rotativa;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]
    public class ReportStockPositionController: Controller
    {
        public ActionResult Index()
        {
            var stock = ProductModel.RescueReportStockPosition();
            return new ViewAsPdf("~/Views/Report/ReportStockPositionView.cshtml", stock);
        }
    }
}