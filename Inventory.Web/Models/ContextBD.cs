using ControleEstoque.Web.Models;
using System.Data.Entity;

namespace Inventory.Web.Models
{
    public class ContextBD : DbContext
    {
        public ContextBD() : base("name=main")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new EntryProductMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new ProviderMap());
            modelBuilder.Configurations.Add(new GroupProductMap());
            modelBuilder.Configurations.Add(new InventoryStockMap());
            modelBuilder.Configurations.Add(new StorageLocationMap());
            modelBuilder.Configurations.Add(new ProductBrandMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductOutputMap());
            modelBuilder.Configurations.Add(new UnitMeasureMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new EmployeeMap());

        }

        public DbSet<CityModel> Cities { get; set; }
        public DbSet<EntryProductModel> EntriesProducts { get; set; }
        public DbSet<ProvinceModel> Provinces { get; set; }
        public DbSet<ProviderModel> Providers { get; set; }
        public DbSet<GroupProductModel> GroupsProducts { get; set; }
        public DbSet<InventoryStockModel> InventoriesStocks { get; set; }
        public DbSet<StorageLocationModel> StoragesLocations { get; set; }
        public DbSet<ProductBrandModel> ProductsBrands { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<RoleModel> RolesUsers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductOutputModel> ProductsOutputs { get; set; }
        public DbSet<UnitMeasureModel> UnitsMeasures { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

    }
}