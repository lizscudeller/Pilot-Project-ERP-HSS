using System;

namespace Inventory.Web.Models
{
    public class ReportProductEntryViewModel
    {
        public DateTime Date { get; set; }
        public string EntryNumber { get; set; }
        public string NameProvider { get; set; }
        public string NameProduct { get; set; }
        public int QuantityProduct { get; set; }
        public string UserName { get; set; }

    }
}