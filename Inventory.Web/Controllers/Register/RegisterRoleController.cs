﻿using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Inventory.Web.Controllers.Register
{
    [Authorize(Roles = "Administrator")]

    public class RegisterRoleController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;
        private const int ActualPage = 1;


        public ActionResult Index()
        {
            ViewBag.ListUsers = Mapper.Map<List<UserViewModel>>(UserModel.RescueList());
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            var list = Mapper.Map<List<RoleViewModel>>(RoleModel.RescueList(ActualPage, _quantMaxLinesPerPage));
            var quant = RoleModel.RescueQuantity();

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RolePage(int page, int lenPage, string filter, string order)
        {
            var list = Mapper.Map<List<RoleViewModel>>(RoleModel.RescueList(page, lenPage, filter, order));

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueRole(int id)
        {
            var ret = Mapper.Map<RoleViewModel>(RoleModel.IdRescue(id));
            return Json(ret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteRole(int id)
        {
            return Json(RoleModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveRole(RoleViewModel model, List<int> idUsers)
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

                model.Users = new List<UserViewModel>();
                if (idUsers == null || idUsers.Count == 0)
                {
                    model.Users.Add(new UserViewModel() { Id = -1 });
                }
                else
                {
                    foreach (var id in idUsers)
                    {
                        model.Users.Add(new UserViewModel() { Id = id });
                    }
                }
                try
                {
                    var vm = Mapper.Map<RoleModel>(model);
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