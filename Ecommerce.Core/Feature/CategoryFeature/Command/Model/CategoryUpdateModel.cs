namespace Ecommerce.Core.Feature.CategoryFeature.Command.Model;

public sealed class CategoryUpdateModel : IRequest<Response<CategoryUpdateResult>>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}
