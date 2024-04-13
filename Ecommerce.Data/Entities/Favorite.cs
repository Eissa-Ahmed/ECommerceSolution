namespace Ecommerce.Data.Entities;

public sealed class Favorite
{
    public string FavoriteId { get; set; } = null!;

    // Foreign keys
    public string UserId { get; set; } = null!;
    public string ProductId { get; set; } = null!;

    // Navigation properties
    public User? User { get; set; }
    public Product? Product { get; set; }
}
