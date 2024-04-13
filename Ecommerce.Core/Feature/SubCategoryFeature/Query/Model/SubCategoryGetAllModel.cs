namespace Ecommerce.Core.Feature.SubCategoryFeature.Query.Model;

public sealed class SubCategoryGetAllModel(string? Id = null) : IRequest<Response<IEnumerable<SubCategoryGetAllResult>>>
{
    public string? Id { get; set; } = Id;
}
