namespace Ecommerce.Core.Mapper.SubCategoryMapper;
public partial class SubCategoryProfile
{
    private void ApplySubCategoryGetByIdMapper()
    {
        CreateMap<SubCategory, SubCategoryGetByIdResult>();
    }
}
