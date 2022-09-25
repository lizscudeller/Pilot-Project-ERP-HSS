using Inventory.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControleEstoque.Web.Models
{
    public class CityMap : EntityTypeConfiguration<CityModel>
    {
        public CityMap()
        {
            ToTable("city");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();

            Property(x => x.IdProvince).HasColumnName("id_province").IsRequired();
            HasRequired(x => x.Province).WithMany().HasForeignKey(x => x.IdProvince).WillCascadeOnDelete(false);
        }
    }
}