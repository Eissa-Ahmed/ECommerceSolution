namespace Ecommerce.Core.Mapper.SubCategoryMapper;

public partial class SubCategoryProfile : Profile
{
    public SubCategoryProfile()
    {
        ApplySubCategoryGetAllMapper();
        ApplySubCategoryGetByIdMapper();
        ApplySubCategoryAddMapper();
        ApplySubCategoryUpdateMapper();
    }
}
