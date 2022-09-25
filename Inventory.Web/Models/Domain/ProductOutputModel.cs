using System;

namespace Inventory.Web.Models
{
    public class ProductOutputModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int IdProduct { get; set; }
        public virtual ProductModel Product { get; set; }

        public int IdProvider { get; set; }
        public virtual ProviderModel Provider { get; set; }

        public string UserName { get; set; }

    }
}