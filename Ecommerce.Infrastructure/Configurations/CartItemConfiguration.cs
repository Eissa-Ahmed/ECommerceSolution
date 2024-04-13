namespace Ecommerce.Infrastructure.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> entity)
    {
        entity.ToTable("CartItem");
        entity.HasKey(k => new { k.CartId, k.ProductId });
    }
}
