using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class UnitMeasureMap : EntityTypeConfiguration<UnitMeasureModel>
    {
        public UnitMeasureMap()
        {
            ToTable("unit_measure");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
            Property(x => x.Initials).HasColumnName("initials").HasMaxLength(3).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();
        }
    }
}