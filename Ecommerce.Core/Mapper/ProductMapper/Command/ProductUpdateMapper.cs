namespace Ecommerce.Core.Mapper.ProductMapper;

public partial class ProductProfile
{
    private void ApplyProductUpdateMapper()
    {
        CreateMap<ProductUpdateModel, Product>();
        CreateMap<Product, ProductUpdateResult>();
    }
}
