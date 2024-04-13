namespace Ecommerce.Core.Mapper.CategoryMapper;
public partial class CategoryProfile
{
    private void ApplyCategoryGetByIdMapper()
    {
        CreateMap<SubCategory, CategoryGetByIdResultSubCategory>();
        CreateMap<Category, CategoryGetByIdResult>()
            .ForMember(dest => dest.subCategories, opt => opt.MapFrom(src => src.SubCategory));
    }
}
