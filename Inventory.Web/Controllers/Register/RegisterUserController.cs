using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RegisterUserController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;
        private const string _mainPassword = "{$127;$188}";
        private const int ActualPage = 1;


        public ActionResult Index()
        {
            ViewBag.MainPassword = _mainPassword;
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            //var list = Mapper.Map<List<UserViewModel>>(UserModel.RescueList(ViewBag.ActualPage, _quantMaxLinesPerPage));
            var list = Mapper.Map<List<UserViewModel>>(UserModel.RescueList(ActualPage, _quantMaxLinesPerPage));
            var quant = UserModel.RescueQuantity(); //estava GroupProductModel

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;

            return View(list);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UserPage(int page, int lenPage, string filter, string order)
        {
            var list = Mapper.Map<List<UserViewModel>>(UserModel.RescueList(page, lenPage, filter, order));

            return Json(list);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RescueUser(int id)
        {
            var vm = Mapper.Map<UserViewModel>(UserModel.IdRescue(id));
            vm.Password = _mainPassword; 

            return Json(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id)
        {
            return Json(UserModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUser(UserViewModel model)
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
                    if (model.Password == _mainPassword)
                    {
                        model.Password = "";
                    }

                    var vm = Mapper.Map<UserModel>(model);
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