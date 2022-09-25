
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class ProductMap : EntityTypeConfiguration<ProductModel>
    {
        public ProductMap()
        {
            ToTable("product");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Code).HasColumnName("code").HasMaxLength(10).IsRequired();
            Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            Property(x => x.CostValue).HasColumnName("cost_value").HasPrecision(7, 2).IsRequired();
            Property(x => x.Price).HasColumnName("price").HasPrecision(7, 2).IsRequired();
            Property(x => x.StorageQuant).HasColumnName("storage_quant").IsRequired();
            Property(x => x.Image).HasColumnName("image").HasMaxLength(100).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();

            Property(x => x.IdUnitMeasure).HasColumnName("id_unit_measure").IsRequired();
            HasRequired(x => x.UnitMeasure).WithMany().HasForeignKey(x => x.IdUnitMeasure).WillCascadeOnDelete(false);

            Property(x => x.IdGroup).HasColumnName("id_group").IsRequired();
            HasRequired(x => x.Group).WithMany().HasForeignKey(x => x.IdGroup).WillCascadeOnDelete(false);

            Property(x => x.IdBrand).HasColumnName("id_brand").IsRequired();
            HasRequired(x => x.Brand).WithMany().HasForeignKey(x => x.IdBrand).WillCascadeOnDelete(false);

            Property(x => x.IdProvider).HasColumnName("id_provider").IsRequired();
            HasRequired(x => x.Provider).WithMany().HasForeignKey(x => x.IdProvider).WillCascadeOnDelete(false);

            Property(x => x.IdStorageLocation).HasColumnName("id_storage_location").IsRequired();
            HasRequired(x => x.StorageLocation).WithMany().HasForeignKey(x => x.IdStorageLocation).WillCascadeOnDelete(false);
        }
    }
}