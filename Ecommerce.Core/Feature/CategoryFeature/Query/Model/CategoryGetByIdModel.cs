namespace Ecommerce.Core.Feature.CategoryFeature.Query.Model;

public sealed class CategoryGetByIdModel(string Id) : IRequest<Response<CategoryGetByIdResult>>
{
    public string Id { get; set; } = Id;
}
