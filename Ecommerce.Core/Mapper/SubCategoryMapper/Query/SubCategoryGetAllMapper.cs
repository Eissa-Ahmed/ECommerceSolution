namespace Ecommerce.Core.Mapper.SubCategoryMapper;


public partial class SubCategoryProfile
{
    private void ApplySubCategoryGetAllMapper()
    {
        CreateMap<SubCategory, SubCategoryGetAllResult>();
    }
}
