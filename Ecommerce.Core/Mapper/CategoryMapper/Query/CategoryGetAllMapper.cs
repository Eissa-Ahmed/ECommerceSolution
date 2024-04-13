namespace Ecommerce.Core.Mapper.CategoryMapper;

public partial class CategoryProfile
{
    private void ApplyCategoryGetAllMapper()
    {
        CreateMap<SubCategory, CategoryGetAllResultSubCategory>();
        CreateMap<Category, CategoryGetAllResult>()
            .ForMember(dest => dest.subCategories, opt => opt.MapFrom(src => src.SubCategory));
    }
}
