namespace Ecommerce.Core.Feature.CategoryFeature.Command.Model;

public sealed class CategoryDeleteModel(string Id) : IRequest<Response<string>>
{
    public string Id { get; set; } = Id;
}
