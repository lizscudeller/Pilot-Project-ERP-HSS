using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Identity;

namespace Inventory.Web.Models
{
    public class EntryOutputProductViewModelModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var values = controllerContext.HttpContext.Request.Form;
            var ret = new EntryOutputProductViewModel() { Products = new Dictionary<int, int>() };

            try
            {
                ret.Date = DateTime.ParseExact(values.Get("date"), "yyyy-MM-dd", null);
                ret.IdProvider = Int32.Parse(values.Get("provider"));


                if (!string.IsNullOrEmpty(values.Get("products")))
                {
                    var products = JsonConvert.DeserializeObject<List<dynamic>>(values.Get("products"));

                    foreach (var product in products)
                    {
                        ret.Products.Add((int)product.IdProduct, (int)product.Quantity);
                    }
                };
            }
            catch 
            {
            }
            return ret;
        }
    }
}