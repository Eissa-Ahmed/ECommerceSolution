namespace Ecommerce.Core.Feature.ProductFeature.Query.Model;

public sealed class ProductGetInSubCategoryModel(string subCategoryId, int pageNumber) : IRequest<Response<ProductGetAllResult>>
{
    public string SubCategoryId { get; } = subCategoryId;
    public int pageNumber { get; } = pageNumber;
}
