namespace Ecommerce.Core.Mapper.CategoryMapper;

public partial class CategoryProfile
{
    private void ApplyCategoryAddMapper()
    {
        CreateMap<CategoryAddModelSubCategory, SubCategory>();
        CreateMap<SubCategory, CategoryAddResultSubCategory>();
        CreateMap<CategoryAddModel, Category>()
            .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.subCategory));

        CreateMap<Category, CategoryAddResult>()
            .ForMember(dest => dest.subCategories, opt => opt.MapFrom(src => src.SubCategory));
    }
}
