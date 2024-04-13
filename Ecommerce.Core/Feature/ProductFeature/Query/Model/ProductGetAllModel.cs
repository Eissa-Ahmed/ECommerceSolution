namespace Ecommerce.Core.Feature.ProductFeature.Query.Model;

public class ProductGetAllModel(int pageNumber) : IRequest<Response<ProductGetAllResult>>
{
    public int pageNumber { get; set; } = pageNumber;
}
