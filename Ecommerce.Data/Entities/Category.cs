namespace Ecommerce.Data.Entities;

public sealed class Category
{
    public Category()
    {
        Products = new HashSet<Product>();
        SubCategory = new HashSet<SubCategory>();
    }
    public string CategoryId { get; set; } = null!;
    public string Name { get; set; } = null!;

    // Navigation properties
    public ICollection<SubCategory> SubCategory { get; set; }
    public ICollection<Product> Products { get; set; }
}
