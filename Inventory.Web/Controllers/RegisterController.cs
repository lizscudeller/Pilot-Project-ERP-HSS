using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class RegisterController : BaseController
    {
        private const int _quantMaxLinesPerPage = 5;





        [Authorize]
        public ActionResult ProductBrand()
        {
            return View();
        }
        [Authorize]
        public ActionResult StorageLocation()
        {
            return View();
        }
        
        [Authorize]
        public ActionResult Product()
        {
            return View();
        }
        [Authorize]
        public ActionResult Country()
        {
            return View();
        }
        [Authorize]
        public ActionResult Province()
        {
            return View();
        }
        [Authorize]
        public ActionResult Provider()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }


    }
}