using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class MMController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}