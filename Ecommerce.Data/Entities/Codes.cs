namespace Ecommerce.Data.Entities;

public sealed class Codes
{
    public Codes()
    {
        createdAt = DateTime.UtcNow;
    }
    public string Id { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateTime createdAt { get; set; }
    public bool IsUsed { get; set; }
    public bool IsActive => this.IsUsed == false && this.createdAt.AddMinutes(10) >= DateTime.UtcNow;
    //Foren Key
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}
