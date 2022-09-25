using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class HRController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}