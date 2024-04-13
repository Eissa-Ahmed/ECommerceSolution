namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Model;

public sealed class SubCategoryUpdateModel : IRequest<Response<SubCategoryUpdateResult>>
{
    public string SubCategoryId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
}
