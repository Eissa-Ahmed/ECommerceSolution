namespace Ecommerce.Core.Feature.ProductFeature.Command.Model;

public sealed class ProductUpdateModel : IRequest<Response<ProductUpdateResult>>
{
    public string ProductId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Image { get; set; }
    public IFormFile? ImageFile { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryId { get; set; } = null!;
    public string SubCategoryId { get; set; } = null!;
}
