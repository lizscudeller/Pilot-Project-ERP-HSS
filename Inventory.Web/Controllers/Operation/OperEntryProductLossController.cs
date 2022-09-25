using Inventory.Web.Models;
using Rotativa;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Inventory.Web.Controllers.Operation
{
    [Authorize(Roles = "Administrator")]
    public class OperEntryProductLossController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Inventories = ProductModel.RescueListInventoryWithDifference();
            return View();
        }

        [HttpGet]
        public JsonResult RescueProductListWithInventoryDifference(string inventory) 
        {
            var ret = ProductModel.RescueProductListWithInventoryDifference(inventory);
            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Savee(List<ProductLossViewModel> data)
        {
            var ret = ProductModel.SaveProductLoss(data);
            return Json(ret);
        }


    }
}