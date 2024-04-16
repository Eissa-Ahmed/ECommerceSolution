namespace Ecommerce.Data.Entities;

public sealed class User : IdentityUser, ISoftDelete
{
    public User()
    {
        Orders = new HashSet<Order>();
        Carts = new HashSet<Cart>();
        Favorites = new HashSet<Favorite>();
        Codes = new HashSet<Codes>();
    }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    // Navigation properties
    public ICollection<Codes> Codes { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
}
