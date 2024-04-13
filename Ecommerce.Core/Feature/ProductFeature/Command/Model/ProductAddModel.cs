namespace Ecommerce.Core.Feature.ProductFeature.Command.Model;

public sealed class ProductAddModel : IRequest<Response<ProductAddResult>>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryId { get; set; } = null!;
    public string SubCategoryId { get; set; } = null!;
}
