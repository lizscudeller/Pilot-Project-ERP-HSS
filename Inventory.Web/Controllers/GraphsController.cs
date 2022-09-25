using Inventory.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Inventory.Web.Controllers
{
    public class GraphsController : BaseController
    {
        [Authorize]
        public ActionResult MontlyLostProducts()
        {

            var month = DateTime.Today.Month;
            var year = DateTime.Today.Year;
            var dayquantity = DateTime.DaysInMonth(year, month);

            var days = new List<int>();
            var lost = new List<int>();
            for (var day = 1; day <= dayquantity; day++)
            {
                days.Add(day);
                lost.Add(0);
            }

            foreach (var lostBd in ProductModel.MonthlyLost(month, year))
            {
                lost[lostBd.Day - 1] = lostBd.Quant;
            }


            ViewBag.Days = days;
            ViewBag.Month = month;
            ViewBag.Year = year;
            ViewBag.Lost = lost;

            return View();
        }
        [Authorize]
        public ActionResult MontlyEntryOutput()
        {
            return View();
        }
    }
}