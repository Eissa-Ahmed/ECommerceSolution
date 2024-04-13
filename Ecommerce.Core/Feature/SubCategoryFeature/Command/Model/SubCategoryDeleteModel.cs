namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Model;

public sealed class SubCategoryDeleteModel(string Id) : IRequest<Response<string>>
{
    public string Id { get; set; } = Id;
}
