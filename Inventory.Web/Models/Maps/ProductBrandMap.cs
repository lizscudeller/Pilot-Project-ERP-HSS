using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class ProductBrandMap : EntityTypeConfiguration<ProductBrandModel>
    {
        public ProductBrandMap()
        {
            ToTable("product_brand");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();
        }
    }
}