using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class ReportController : BaseController
    {
        [Authorize]
        public ActionResult Resupply()
        {
            return View();
        }
    }
}