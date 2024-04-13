namespace Ecommerce.Core.Feature.SubCategoryFeature.Query.Model;

public sealed class SubCategoryGetByIdModel(string Id) : IRequest<Response<SubCategoryGetByIdResult>>
{
    public string Id { get; set; } = Id;
}
