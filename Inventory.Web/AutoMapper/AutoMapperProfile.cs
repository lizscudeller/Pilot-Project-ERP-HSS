using AutoMapper;
using Inventory.Web.Models;

namespace Inventory.Web
{
    public static class AutoMapperProfile
    {
        public static IMapper CreateConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CityViewModel, CityModel>().ReverseMap();
                cfg.CreateMap<CountryViewModel, CountryModel>().ReverseMap();
                cfg.CreateMap<ProvinceViewModel, ProvinceModel>().ReverseMap();
                cfg.CreateMap<ProviderViewModel, ProviderModel>().ReverseMap();
                cfg.CreateMap<GroupProductViewModel, GroupProductModel>().ReverseMap();
                cfg.CreateMap<StorageLocationViewModel, StorageLocationModel>().ReverseMap();
                cfg.CreateMap<ProductBrandViewModel, ProductBrandModel>().ReverseMap();
                cfg.CreateMap<RoleViewModel, RoleModel>().ReverseMap();
                cfg.CreateMap<ProductViewModel, ProductModel>().ReverseMap();
                cfg.CreateMap<UnitMeasureViewModel, UnitMeasureModel>().ReverseMap();
                cfg.CreateMap<UserViewModel, UserModel>().ReverseMap();
                cfg.CreateMap<EmployeeViewModel, EmployeeModel>().ReverseMap();

            }).CreateMapper();

            return config;
        }
    }
}