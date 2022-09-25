using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]

    public class RegisterStorageLocationController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;
        private const int ActualPage = 1;


        public ActionResult Index()
        {
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            var list = Mapper.Map<List<StorageLocationViewModel>>(StorageLocationModel.RescueList(ActualPage, _quantMaxLinesPerPage));
            var quant = StorageLocationModel.RescueQuantity();

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult StorageLocationPage(int page, int lenPage, string filter, string order)
        {
            var list = Mapper.Map<List<StorageLocationViewModel>>(StorageLocationModel.RescueList(page, lenPage, filter, order));

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueStorageLocation(int id)
        {
            var vm = Mapper.Map<StorageLocationViewModel>(StorageLocationModel.IdRescue(id));
            return Json(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteStorageLocation(int id)
        {
            return Json(StorageLocationModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveStorageLocation(StorageLocationViewModel model)
        {
            var result = "OK";
            var message = new List<string>();
            var idSaved = string.Empty;
            if (!ModelState.IsValid)
            {
                result = "Warning";
                message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var vm = Mapper.Map<StorageLocationModel>(model);
                    var id = vm.Savee();
                    if (id > 0)
                    {
                        idSaved = id.ToString();
                    }
                    else
                    {
                        result = "Error";
                    }
                }


                catch (Exception ex)
                {
                    result = "Error";
                }


            }
            return Json(new { Result = result, Message = message, IdSaved = idSaved });

        }
    }
}