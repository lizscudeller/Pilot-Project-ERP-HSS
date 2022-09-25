using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class EntryProductMap : EntityTypeConfiguration<EntryProductModel>
    {
        public EntryProductMap()
        {
            ToTable("entry_product");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Number).HasColumnName("number").HasMaxLength(10).IsRequired();
            Property(x => x.Date).HasColumnName("date").IsRequired();
            Property(x => x.Quantity).HasColumnName("quant").IsRequired();

            Property(x => x.IdProduct).HasColumnName("id_product").IsRequired();
            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.IdProduct).WillCascadeOnDelete(false);

            Property(x => x.IdProvider).HasColumnName("id_provider").IsRequired();
            HasRequired(x => x.Provider).WithMany().HasForeignKey(x => x.IdProvider).WillCascadeOnDelete(false);

            Property(x => x.UserName).HasColumnName("user_name").IsRequired();



        }
    }
}
