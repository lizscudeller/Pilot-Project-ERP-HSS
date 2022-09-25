using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models
{
    public class ReportProductLossViewModel
    {
        public DateTime Date { get; set; }
        public string CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public int QuantityProduct { get; set; }
        public int Count { get; set; }
        public string Reason { get; set; }

    }
}