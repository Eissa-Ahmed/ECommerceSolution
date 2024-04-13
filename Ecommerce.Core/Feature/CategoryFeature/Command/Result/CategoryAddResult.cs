namespace Ecommerce.Core.Feature.CategoryFeature.Command.Result;

public struct CategoryAddResult
{
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public IEnumerable<CategoryAddResultSubCategory> subCategories { get; set; }
}
public struct CategoryAddResultSubCategory
{
    public string SubCategoryId { get; set; }
    public string Name { get; set; }
}
