using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class RoleMap : EntityTypeConfiguration<RoleModel>
    {
        public RoleMap()
        {
            ToTable("role");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();

            HasMany(x => x.Users).WithMany(x => x.Roles)
                .Map(x =>
                {
                    x.ToTable("role_users");
                    x.MapLeftKey("id_role");
                    x.MapRightKey("id_users");
                });
        }
    }
}