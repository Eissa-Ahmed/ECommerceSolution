namespace Ecommerce.Core.Mapper.SubCategoryMapper;
public partial class SubCategoryProfile
{
    private void ApplySubCategoryUpdateMapper()
    {
        CreateMap<SubCategoryUpdateModel, SubCategory>();
        CreateMap<SubCategory, SubCategoryUpdateResult>();
    }
}
