namespace Ecommerce.Core.Mapper.CategoryMapper;

public partial class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        ApplyCategoryAddMapper();
        ApplyCategoryGetAllMapper();
        ApplyCategoryGetByIdMapper();
        ApplyCategoryUpdateMapper();
    }
}
