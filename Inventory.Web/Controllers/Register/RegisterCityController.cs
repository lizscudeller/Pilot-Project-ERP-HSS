using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]

    public class RegisterCityController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;
        private const int ActualPage = 1;


        public ActionResult Index()
        {
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            var list = CityModel.RescueList(ActualPage, _quantMaxLinesPerPage);
            var quant = CityModel.RescueQuantity();

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;
            ViewBag.Countries = Mapper.Map<List<CountryViewModel>>(CountryModel.RescueList());
            ViewBag.Countries.Insert(0, new CountryViewModel { Id = -1, Name = "-- Not Selected --" });


            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CityPage(int page, int lenPage, string filter, string order)
        {
            var list = CityModel.RescueList(page, lenPage, filter, order);

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueCity(int id)
        {
            var vm = CityModel.IdRescue(id);
            return Json(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueCitiesbyProvinces(int idProvince)
        {
            var list = CityModel.RescueList(idProvince: idProvince);
            list.Insert(0, new CityViewModel { Id = -1, Name = "-- Not Selected --" });
            return Json(list);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteCity(int id)
        {
            return Json(CityModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveCity(CityViewModel model)
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
                    var vm = Mapper.Map<CityModel>(model);
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