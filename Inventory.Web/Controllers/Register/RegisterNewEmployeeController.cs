using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Administrator, Operator")]
    public class RegisterNewEmployeeController : BaseController
    {
        public ActionResult FirstTab()
        {
            return PartialView("_FirstTab");
        }

        public ActionResult SecondTab()
        {
            return PartialView("_SecondTab");
        }
        public ActionResult ThirdTab()
        {
            return PartialView("_ThirdTab");
        }
        public ActionResult FourthTab()
        {
            return PartialView("_FourthTab");
        }
        public ActionResult FifthTab()
        {
            return PartialView("_FifthTab");
        }
        public ActionResult FifthTab_1()
        {
            return PartialView("_FifthTab_1");
        }
        public ActionResult FifthTab_2()
        {
            return PartialView("_FifthTab_2");
        }
        public ActionResult FifthTab_3()
        {
            return PartialView("_FifthTab_3");
        }

        public ActionResult SixtyTab()
        {
            return PartialView("_SixtyTab");
        }

        private const int _quantMaxLinesPerPage = 5;
        private const int ActualPage = 1;

        public ActionResult Index()
        {
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            //var list = Mapper.Map<List<EmployeeViewModel>>(EmployeeModel.RescueList(ActualPage, _quantMaxLinesPerPage));
            var list = Mapper.Map<List<EmployeeViewModel>>(EmployeeModel.RescueList(ActualPage, _quantMaxLinesPerPage));

            var quant = EmployeeModel.RescueQuantity();

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;


            List<SelectListItem> payrollinfo = new List<SelectListItem>(){
                new SelectListItem { Text = "", Value = "Empty" },
                new SelectListItem { Text = "Salary", Value = "Salary" },
                new SelectListItem { Text = "Sick Salary", Value = "Sick Salary" },
                new SelectListItem { Text = "Vacation Salary", Value = "Vacation Salary" },
                new SelectListItem { Text = "Overtime Rate", Value = "Overtime Rate" },
                new SelectListItem { Text = "Regular Pay", Value = "Regular Pay" },
                new SelectListItem { Text = "Sick Hourly", Value = "Sick Hourly" },
                new SelectListItem { Text = "Vacation Hourly", Value = "Vacation Hourly" },
                new SelectListItem { Text = "Bonus", Value = "Bonus" },


            };
            ViewBag.PayrollInfo = payrollinfo;




            List<SelectListItem> payrollfrequency = new List<SelectListItem>(){
                new SelectListItem { Text = "Weekly", Value = "Weekly" },
                new SelectListItem { Text = "Biweekly", Value = "Biweekly" },
                new SelectListItem { Text = "Monthly", Value = "Monthly" },
                new SelectListItem { Text = "Other", Value = "Other" },


            };
            ViewBag.PayrollFrequency = payrollfrequency;


            List<SelectListItem> gender = new List<SelectListItem>(){
                new SelectListItem { Text = "Male", Value = "0" },
                new SelectListItem { Text = "Female", Value = "1" },
                new SelectListItem { Text = "Other", Value = "2" },

            };
            ViewBag.Gender = gender;


            List<SelectListItem> marital = new List<SelectListItem>(){
                new SelectListItem { Text = "Single", Value = "Single" },
                new SelectListItem { Text = "Married", Value = "Married" },
                new SelectListItem { Text = "Widowed", Value = "Widowed" },
                new SelectListItem { Text = "Divorced", Value = "Divorced" },

            };
            ViewBag.Marital = marital;


            List<SelectListItem> ethnicity = new List<SelectListItem>(){
                new SelectListItem { Text = "White", Value = "White" },
                new SelectListItem { Text = "Asian", Value = "Asian" },
                new SelectListItem { Text = "African American", Value = "African American" },
                new SelectListItem { Text = "Hispanic", Value = "Hispanic" },
                new SelectListItem { Text = "Other Pacific Islander", Value = "Other Pacific Islander" },
                new SelectListItem { Text = "American Indian", Value = "American Indian" },


            };
            ViewBag.Ethnicity = ethnicity;

            List<SelectListItem> yesno = new List<SelectListItem>(){
                new SelectListItem { Text = "Yes", Value = "0" },
                new SelectListItem { Text = "No", Value = "1" },

            };
            ViewBag.YesNo = yesno;

            return View(list);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EmployeePage(int page, int lenPage, string filter, string order)
        {
            var list = Mapper.Map<List<EmployeeViewModel>>(EmployeeModel.RescueList(page, lenPage, filter, order));

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueEmployee(int id)
        {
            var vm = Mapper.Map<EmployeeViewModel>(EmployeeModel.IdRescue(id));

            //added
            //string json = JsonSerializer.Serialize(vm.DateBirth);

            //added

            return Json(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteEmployee(int id)
        {
            return Json(EmployeeModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveEmployee(EmployeeViewModel model)
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
                    var vm = Mapper.Map<EmployeeModel>(model);
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


                //        var vm = new EmployeeViewModel()
                //    {
                //        Id = (Request.Form["Id"]).ToInt32(),
                //        LegalName = Request.Form["LegalName"],
                //        LegalSurname = Request.Form["LegalSurname"],
                //        //EmployeeType = (Request.Form["EmployeeType"]).ToInt32(),
                //        PrintName = Request.Form["PrintName"],
                //        Ssn = (Request.Form["Ssn"]).ToInt32(),
                //        Gender = (Request.Form["Gender"]).ToInt32(),
                //        //DateBirth = DateTime.Parse(Request.Form["DateBirth"]),
                //        MaritalStatus = Request.Form["MaritalStatus"],
                //        UsCitizen = (Request.Form["UsCitizen"]).ToInt32(),
                //        Ethnicity = Request.Form["Ethnicity"],
                //        Disability = (Request.Form["Disability"]).ToInt32(),
                //        DisabilityDescription = Request.Form["DisabilityDescription"],
                //        I9Form = (Request.Form["I9Form"]).ToInt32(),
                //        //WorkExpires = DateTime.Parse(Request.Form["WorkExpires"]), 
                //        UsVeteran = (Request.Form["UsVeteran"]).ToInt32(),
                //        VeteranStatus = Request.Form["VeteranStatus"],

                //        Address1 = Request.Form["Address1"],
                //        Address2 = Request.Form["Address2"],
                //        City = Request.Form["City"],
                //        StateProvince = Request.Form["StateProvince"],
                //        PostalCode = Request.Form["PostalCode"],
                //        PhoneNumber = Request.Form["PhoneNumber"],
                //        MobileNumber = Request.Form["MobileNumber"],
                //        Email = Request.Form["Email"],
                //        ContactName1 = Request.Form["ContactName1"],
                //        ContactPhone1 = Request.Form["ContactPhone1"],
                //        ContactRelation1 = Request.Form["ContactRelation1"],
                //        ContactName2 = Request.Form["ContactName2"],
                //        ContactPhone2 = Request.Form["ContactPhone2"],
                //        ContactRelation2 = Request.Form["ContactRelation2"],

                //        Active = (Request.Form["Active"] == "true"),


                //};

                //    var context = new ValidationContext(vm);
                //    var results = new List<ValidationResult>();
                //    var valid = Validator.TryValidateObject(vm, context, results);


                //    if (!valid)
                //    {
                //        result = "Warning";
                //        message = results.Select(x => x.ErrorMessage).ToList();
                //    }
                //    else
                //    {
                //        var model = new EmployeeModel()
                //        {
                //            Id = vm.Id,
                //            LegalName = vm.LegalName,
                //            LegalSurname = vm.LegalSurname,
                //            PrintName = vm.PrintName,
                //            EmployeeType = vm.EmployeeType,
                //            Ssn = vm.Ssn,
                //            Gender = vm.Gender,
                //            DateBirth = vm.DateBirth,
                //            MaritalStatus = vm.MaritalStatus,
                //            UsCitizen = vm.UsCitizen,
                //            Ethnicity = vm.Ethnicity,
                //            Disability = vm.Disability,
                //            DisabilityDescription = vm.DisabilityDescription,
                //            I9Form = vm.I9Form,
                //            WorkExpires = vm.WorkExpires,
                //            UsVeteran = vm.UsVeteran,
                //            VeteranStatus = vm.VeteranStatus,

                //            Address1 = vm.Address1,
                //            Address2 = vm.Address2,
                //            City = vm.City,
                //            StateProvince = vm.StateProvince,
                //            PostalCode = vm.PostalCode,
                //            PhoneNumber = vm.PhoneNumber,
                //            MobileNumber = vm.MobileNumber,
                //            Email = vm.Email,
                //            ContactName1 = vm.ContactName1,
                //            ContactPhone1 = vm.ContactPhone1,
                //            ContactRelation1 = vm.ContactRelation1,
                //            ContactName2 = vm.ContactName2,
                //            ContactPhone2 = vm.ContactPhone2,
                //            ContactRelation2 = vm.ContactRelation2,



                //            Active = vm.Active,

                //        };

            }
            return Json(new { Result = result, Message = message, IdSaved = idSaved });

        }
    }
}