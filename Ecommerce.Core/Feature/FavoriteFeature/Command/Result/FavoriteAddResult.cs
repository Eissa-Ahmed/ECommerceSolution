namespace Ecommerce.Core.Feature.FavoriteFeature.Command.Result;

public struct FavoriteAddResult
{
    public string FavoriteId { get; set; }
    public string UserId { get; set; }
    public string ProductId { get; set; }
}
