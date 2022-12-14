//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.entry_product = new HashSet<entry_product>();
            this.inventory_stock = new HashSet<inventory_stock>();
            this.product_output = new HashSet<product_output>();
        }
    
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public decimal cost_value { get; set; }
        public decimal price { get; set; }
        public int storage_quant { get; set; }
        public int id_unit_measure { get; set; }
        public int id_group { get; set; }
        public int id_brand { get; set; }
        public int id_provider { get; set; }
        public int id_storage_location { get; set; }
        public bool active { get; set; }
        public string image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<entry_product> entry_product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inventory_stock> inventory_stock { get; set; }
        public virtual product_brand product_brand { get; set; }
        public virtual product_group product_group { get; set; }
        public virtual provider provider { get; set; }
        public virtual storage_location storage_location { get; set; }
        public virtual unit_measure unit_measure { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product_output> product_output { get; set; }
    }
}
