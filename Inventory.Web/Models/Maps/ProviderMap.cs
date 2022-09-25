using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class ProviderMap : EntityTypeConfiguration<ProviderModel>
    {
        public ProviderMap()
        {
            ToTable("provider");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(60).IsRequired();
            Property(x => x.CorporateName).HasColumnName("corporate_name").HasMaxLength(100).IsOptional();
            Property(x => x.DocNum).HasColumnName("doc_num").HasMaxLength(20).IsOptional();
            Property(x => x.Type).HasColumnName("type").IsRequired();
            Property(x => x.Phone).HasColumnName("phone").HasMaxLength(20).IsRequired();
            Property(x => x.Contact).HasColumnName("contact").HasMaxLength(60).IsRequired();
            Property(x => x.Address).HasColumnName("address").HasMaxLength(100).IsRequired();
            Property(x => x.Number).HasColumnName("number").HasMaxLength(20).IsRequired();
            Property(x => x.Instruction).HasColumnName("instruction").HasMaxLength(100).IsOptional();
            Property(x => x.PostalCode).HasColumnName("postal_code").HasMaxLength(10).IsOptional();
            Property(x => x.Active).HasColumnName("active").IsRequired();

            Property(x => x.IdCountry).HasColumnName("id_country").IsRequired();
            HasRequired(x => x.Country).WithMany().HasForeignKey(x => x.IdCountry).WillCascadeOnDelete(false);

            Property(x => x.IdProvince).HasColumnName("id_province").IsRequired();
            HasRequired(x => x.Province).WithMany().HasForeignKey(x => x.IdProvince).WillCascadeOnDelete(false);

            Property(x => x.IdCity).HasColumnName("id_city").IsRequired();
            HasRequired(x => x.City).WithMany().HasForeignKey(x => x.IdCity).WillCascadeOnDelete(false);
        }
    }
}