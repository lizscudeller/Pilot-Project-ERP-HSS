using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class CRMController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}