namespace Ecommerce.Core.Feature.ProductFeature.Command.Result;

public struct ProductUpdateResult
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryId { get; set; }
    public string SubCategoryId { get; set; }
    public string ImageBase64 { get; set; }
}
