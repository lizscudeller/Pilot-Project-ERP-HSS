using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Inventory.Web.Models
{
    public class InventoryStockMap : EntityTypeConfiguration<InventoryStockModel>
    {
        public InventoryStockMap()
        {
            ToTable("inventory_stock");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Date).HasColumnName("date").IsRequired();
            Property(x => x.Reason).HasColumnName("reason").HasMaxLength(100).IsOptional();
            Property(x => x.StorageQuantity).HasColumnName("storage_quant").IsRequired();
            Property(x => x.QuantityInventory).HasColumnName("quant_inventory").IsRequired();

            Property(x => x.IdProduct).HasColumnName("id_product").IsRequired();
            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.IdProduct).WillCascadeOnDelete(false);


        }
    }
}