namespace Ecommerce.Core.Feature.FavoriteFeature.Command.Model;

public sealed class FavoriteAddModel(string ProductId) : IRequest<Response<FavoriteAddResult>>
{
    public string ProductId { get; set; } = ProductId;
}
