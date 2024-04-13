namespace Ecommerce.Data.Entities;

public sealed class SubCategory
{
    public SubCategory()
    {
        Products = new HashSet<Product>();
    }
    public string SubCategoryId { get; set; } = null!;
    public string Name { get; set; } = null!;

    // Foreign key
    public string CategoryId { get; set; } = null!;

    // Navigation properties
    public Category? Category { get; set; }
    public ICollection<Product> Products { get; set; }
}
