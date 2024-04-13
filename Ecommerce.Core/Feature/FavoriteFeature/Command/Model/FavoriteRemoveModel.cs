namespace Ecommerce.Core.Feature.FavoriteFeature.Command.Model;

public sealed class FavoriteRemoveModel(string favoriteId) : IRequest<Response<string>>
{
    public string favoriteId { get; set; } = favoriteId;
}
