namespace Ecommerce.Core.Feature.CategoryFeature.Command.Model;

public sealed class CategoryAddModel : IRequest<Response<CategoryAddResult>>
{
    public string Name { get; set; } = null!;
    public IEnumerable<CategoryAddModelSubCategory>? subCategory { get; set; }

}
public sealed class CategoryAddModelSubCategory
{
    public string Name { get; set; } = null!;

}
