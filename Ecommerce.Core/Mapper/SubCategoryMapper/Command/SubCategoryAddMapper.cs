namespace Ecommerce.Core.Mapper.SubCategoryMapper;
public partial class SubCategoryProfile
{
    private void ApplySubCategoryAddMapper()
    {
        CreateMap<SubCategoryAddModel, SubCategory>();
        CreateMap<SubCategory, SubCategoryAddResult>();
    }
}
