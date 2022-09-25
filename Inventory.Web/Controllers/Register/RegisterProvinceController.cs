using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]
    public class RegisterProvinceController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;
        private const int ActualPage = 1;


        public ActionResult Index()
        {
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            //var list = Mapper.Map<List<ProvinceViewModel>>(ProvinceModel.RescueList(ViewBag.ActualPage, _quantMaxLinesPerPage));

            var list = Mapper.Map<List<ProvinceViewModel>>(ProvinceModel.RescueList(ActualPage, _quantMaxLinesPerPage));
            var quant = ProvinceModel.RescueQuantity();

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;
            ViewBag.Countries = Mapper.Map<List<CountryViewModel>>(CountryModel.RescueList());
            ViewBag.Countries.Insert(0, new CountryViewModel { Id = -1, Name = "-- Not Selected --" });

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ProvincePage(int page, int lenPage, string filter, string order)
        {
            var list = Mapper.Map<List<ProvinceViewModel>>(ProvinceModel.RescueList(page, lenPage, filter, order));

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueProvicesbyCountry(int idCountry)
        {
            var list = Mapper.Map<List<ProvinceViewModel>>(ProvinceModel.RescueList(idCountry: idCountry));
            list.Insert(0, new ProvinceViewModel { Id = -1, Name = "-- Not Selected --" });

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueProvince(int id)
        {
            // throw new Exception(); forcando erro
            var vm = Mapper.Map<ProvinceViewModel>(ProvinceModel.IdRescue(id));
            return Json(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteProvince(int id)
        {
            return Json(ProvinceModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveProvince(ProvinceViewModel model)
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
                    var vm = Mapper.Map<ProvinceModel>(model);
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