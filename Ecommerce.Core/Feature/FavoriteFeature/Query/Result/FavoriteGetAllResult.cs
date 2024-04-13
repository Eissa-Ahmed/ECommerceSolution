namespace Ecommerce.Core.Feature.FavoriteFeature.Query.Result;

public class FavoriteGetAllResult
{
    public string ProductId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryId { get; set; } = null!;
    public string SubCategoryId { get; set; } = null!;
    public string ImageBase64 { get; set; } = null!;
}
