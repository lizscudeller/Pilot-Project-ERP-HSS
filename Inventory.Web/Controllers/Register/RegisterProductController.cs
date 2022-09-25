using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers.Register
{
    [Authorize(Roles = "Administrator, Operator")]
    public class RegisterProductController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;
        private const int ActualPage = 1;


        public ActionResult Index()
        {
            ViewBag.ListLenPage = new SelectList(new int[] { _quantMaxLinesPerPage, 10, 15, 20 }, _quantMaxLinesPerPage);
            ViewBag.QuantMaxLinesPerPage = _quantMaxLinesPerPage;
            ViewBag.ActualPage = 1;

            //var list = Mapper.Map<List<ProductViewModel>>(ProductModel.RescueList(ViewBag.ActualPage, _quantMaxLinesPerPage));
            var list = Mapper.Map<List<ProductViewModel>>(ProductModel.RescueList(ActualPage, _quantMaxLinesPerPage));
            var quant = ProductModel.RescueQuantity();

            var difQuantPages = (quant % ViewBag.QuantMaxLinesPerPage) > 0 ? 1 : 0;
            ViewBag.QuantPages = (quant / ViewBag.QuantMaxLinesPerPage) + difQuantPages;
            ViewBag.UnitsMeasure = Mapper.Map<List<UnitMeasureViewModel>>(UnitMeasureModel.RescueList(1,9999));
            ViewBag.Groups = Mapper.Map<List<GroupProductViewModel>>(GroupProductModel.RescueList(1, 9999));
            ViewBag.Brands = Mapper.Map<List<ProductBrandViewModel>>(ProductBrandModel.RescueList(1, 9999));
            ViewBag.Providers = Mapper.Map<List<ProviderViewModel>>(ProviderModel.RescueList(1, 9999)); //nao deveria ter nada dentro dos paranteses
            ViewBag.StorageLocations = Mapper.Map<List<StorageLocationViewModel>>(StorageLocationModel.RescueList(1, 9999));

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ProductPage(int page, int lenPage, string filter, string order)
        {
            var list = Mapper.Map<List<ProductViewModel>>(ProductModel.RescueList(page, lenPage, filter, order));

            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueProduct(int id)
        {
            var vm = Mapper.Map<ProductViewModel>(ProductModel.IdRescue(id));
            return Json(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RescueStorageQuantProduct(int id)
        {
            var model = ProductModel.IdRescue(id);
            if (model != null)
            {
                return Json(new { OK = true, Result = model.StorageQuant });
            }
            else
            {
                return Json(new { OK = false });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteProduct(int id)
        {
            return Json(ProductModel.IdDelete(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveProduct()
        {
            var result = "OK";
            var message = new List<string>();
            var idSaved = string.Empty;

            var nameImageFile = "";
            HttpPostedFileBase archive = null;
            if (Request.Files.Count > 0)
            {
                archive = Request.Files[0];
                nameImageFile = Guid.NewGuid().ToString() + ".jpg"; //generates random name for product images
            }
            
            var vm = new ProductViewModel()
            {
                Id = (Request.Form["Id"]).ToInt32(),
                Code = Request.Form["Code"],
                Name = Request.Form["Name"],
                CostValue = (Request.Form["CostValue"]).ToDecimal(),
                Price = (Request.Form["Price"]).ToDecimal(),
                StorageQuant = (Request.Form["StorageQuant"]).ToInt32(),
                IdUnitMeasure = (Request.Form["IdUnitMeasure"]).ToInt32(),
                IdGroup = (Request.Form["IdGroup"]).ToInt32(),
                IdBrand = (Request.Form["IdBrand"]).ToInt32(),
                IdProvider = (Request.Form["IdProvider"]).ToInt32(),
                IdStorageLocation = (Request.Form["IdStorageLocation"]).ToInt32(),
                Active = (Request.Form["Active"] == "true"),
                Image = nameImageFile
            };

            var context = new ValidationContext(vm);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(vm, context, results);


            if (!valid)
            {
                result = "Warning";
                message = results.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var model = new ProductModel()
                {
                    Id = vm.Id,
                    Code = vm.Code,
                    Name = vm.Name,
                    CostValue = vm.CostValue,
                    Price = vm.Price,
                    StorageQuant = vm.StorageQuant,
                    IdUnitMeasure = vm.IdUnitMeasure,
                    IdGroup = vm.IdGroup,
                    IdBrand = vm.IdBrand,
                    IdProvider = vm.IdProvider,
                    IdStorageLocation = vm.IdStorageLocation,
                    Active = vm.Active,
                    Image = vm.Image
                };

                try
                {
                    var nameImageFilePrevious = "";
                    if (model.Id > 0)
                    {
                        nameImageFilePrevious = ProductModel.RescueImageId(model.Id);

                    }

                    var id = model.Savee();
                    if (id > 0)
                    {
                        idSaved = id.ToString();
                        if (!string.IsNullOrEmpty(nameImageFile) && archive != null)
                        {
                            var dir = Server.MapPath("~/Content/Images");
                            var archivepath = Path.Combine(dir, nameImageFile);
                            archive.SaveAs(archivepath);    

                            if (!string.IsNullOrEmpty(nameImageFilePrevious))
                            {
                                var pathPreviousImage = Path.Combine(dir, nameImageFilePrevious);
                                System.IO.File.Delete(pathPreviousImage);
                            }
                        }
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