
namespace Ecommerce.Core.Mapper.ProductMapper;

public partial class ProductProfile : Profile
{
    public ProductProfile()
    {
        ApplyProductGetAllMapper();
        ApplyProductAddMapper();
        ApplyProductUpdateMapper();
    }
}
