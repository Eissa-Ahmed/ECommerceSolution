namespace Ecommerce.Core.Feature.ProductFeature.Command.Model;

public sealed class ProductDeleteModel(string ProductId) : IRequest<Response<string>>
{
    public string ProductId { get; set; } = ProductId;
}
