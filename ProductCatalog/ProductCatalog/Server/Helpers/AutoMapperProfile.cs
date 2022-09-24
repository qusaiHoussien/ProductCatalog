using AutoMapper;
namespace ProductCatalog.Server.Helpers
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Product, ProductForAdd>();
            CreateMap<ProductForAdd, Product>();
            CreateMap<Product, ProductForEdit>();
            CreateMap<ProductForEdit, Product>();
            CreateMap<ProductAttributeMapping, ProductAttributeMappingDto>();
            CreateMap<ProductAttributeMappingDto, ProductAttributeMapping>();
            CreateMap<ProductCategoryMapping, ProductCategoryMappingDto>();
            CreateMap<ProductCategoryMappingDto, ProductCategoryMapping>();
            CreateMap<User, UserForRegister>();
            CreateMap<UserForRegister, User>();
            CreateMap<Picture, PictureDto>();
            CreateMap<PictureDto, Picture>();
            CreateMap<ProductAttribute, AttributeDto>();
            CreateMap<AttributeDto, ProductAttribute>();
        }
    }
}