namespace Ecommerce.Core.Feature.CategoryFeature.Query.Result;

public struct CategoryGetByIdResult
{
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public IEnumerable<CategoryGetByIdResultSubCategory> subCategories { get; set; }
}
public struct CategoryGetByIdResultSubCategory
{
    public string SubCategoryId { get; set; }
    public string Name { get; set; }
}
