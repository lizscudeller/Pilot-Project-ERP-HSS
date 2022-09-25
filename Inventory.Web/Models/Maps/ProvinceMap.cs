using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class ProvinceMap : EntityTypeConfiguration<ProvinceModel>
    {
        public ProvinceMap()
        {
            ToTable("province");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
            Property(x => x.ProvinceCode).HasColumnName("pcode").HasMaxLength(2).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();
            Property(x => x.IdCountry).HasColumnName("id_country").IsRequired();
            HasRequired(x => x.Country).WithMany().HasForeignKey(x => x.IdCountry).WillCascadeOnDelete(false);
        }
    }
}