namespace Ecommerce.Data.Entities;

public sealed class Product : ISoftDelete
{
    public Product()
    {
        CartItems = new HashSet<CartItem>();
        OrderDetails = new HashSet<OrderDetails>();
    }
    public string ProductId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int StockQuantity { get; set; }

    // Foreign keys
    public string CategoryId { get; set; } = null!;
    public string SubCategoryId { get; set; } = null!;

    // Navigation properties
    public Category? Category { get; set; }
    public Favorite? Favorites { get; set; }
    public SubCategory? SubCategory { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
}
