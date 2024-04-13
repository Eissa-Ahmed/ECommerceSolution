namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Model;

public sealed class SubCategoryAddModel : IRequest<Response<SubCategoryAddResult>>
{
    public string Name { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
}
