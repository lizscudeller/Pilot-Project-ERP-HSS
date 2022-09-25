using System;
using System.Collections.Generic;


namespace Inventory.Web.Models
{
    public class EntryOutputProductViewModel
    {
        public DateTime Date { get; set; }
        
        public Dictionary<int, int> Products { get; set; }

        public int IdProvider { get; set; }

        public string UserName { get; set; }

    }
}