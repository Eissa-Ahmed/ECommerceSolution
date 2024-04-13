namespace Ecommerce.Core.Mapper.ProductMapper;

public partial class ProductProfile
{
    private void ApplyProductAddMapper()
    {
        CreateMap<ProductAddModel, Product>();
        CreateMap<Product, ProductAddResult>();
    }
}
