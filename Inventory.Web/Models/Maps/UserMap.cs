using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class UserMap : EntityTypeConfiguration<UserModel>
    {
        public UserMap()
        {
            ToTable("users");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Login).HasColumnName("login").HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasColumnName("password").HasMaxLength(32).IsRequired();
            Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            Property(x => x.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
        }
    }
}