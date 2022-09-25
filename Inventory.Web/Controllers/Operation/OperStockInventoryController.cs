using Inventory.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]


    public class OperStockInventoryController : BaseController
    {
        public ActionResult Index()
        {

            var model = ProductModel.RescueListForInventory();
            return View(model);
        }
        [HttpPost]
        public JsonResult Save(List<ItemInventoryViewModel> data)
        {
            var ok = ProductModel.SaveInventory(data);
            return Json(new { OK = ok });
        }
    }
}