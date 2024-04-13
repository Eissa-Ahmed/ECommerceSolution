namespace Ecommerce.Core.Mapper.CategoryMapper;


public partial class CategoryProfile
{
    private void ApplyCategoryUpdateMapper()
    {
        CreateMap<CategoryUpdateModel, Category>();
        CreateMap<Category, CategoryUpdateResult>();

    }
}
