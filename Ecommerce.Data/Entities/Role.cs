namespace Ecommerce.Data.Entities;

public sealed class Role : IdentityRole
{
    public string CreatedBy { get; set; } = null!;
}
