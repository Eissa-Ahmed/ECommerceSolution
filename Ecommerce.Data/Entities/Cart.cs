namespace Ecommerce.Data.Entities;

public sealed class Cart
{
    public Cart()
    {
        CartItems = new HashSet<CartItem>();
    }
    public string CartId { get; set; } = null!;

    // Foreign keys
    public string UserId { get; set; } = null!;

    // Navigation properties
    public User? User { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
