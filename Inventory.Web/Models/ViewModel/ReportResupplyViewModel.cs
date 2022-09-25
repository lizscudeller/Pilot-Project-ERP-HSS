using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models
{
    public class ReportResupplyViewModel
    {
        public string CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public int QuantityProduct { get; set; }
        public int Purchase { get; set; }

    }
}