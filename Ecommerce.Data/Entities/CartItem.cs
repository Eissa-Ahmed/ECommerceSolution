namespace Ecommerce.Data.Entities;

public sealed class CartItem
{
    public int Quantity { get; set; }

    // Foreign keys
    public string ProductId { get; set; } = null!;
    public string CartId { get; set; } = null!;

    // Navigation properties
    public Product? Product { get; set; }
    public Cart? Cart { get; set; }
}
