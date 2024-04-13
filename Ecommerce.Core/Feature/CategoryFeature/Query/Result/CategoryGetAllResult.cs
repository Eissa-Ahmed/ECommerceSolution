namespace Ecommerce.Core.Feature.CategoryFeature.Query.Result;

public struct CategoryGetAllResult
{
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public IEnumerable<CategoryGetAllResultSubCategory> subCategories { get; set; }
}
public struct CategoryGetAllResultSubCategory
{
    public string SubCategoryId { get; set; }
    public string Name { get; set; }
}