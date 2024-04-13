namespace Ecommerce.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> entity)
    {
        entity.ToTable("Cart");
        entity.HasKey(k => k.CartId);

        entity.Property(p => p.CartId).ValueGeneratedOnAdd();

        entity.HasMany(m => m.CartItems).WithOne(o => o.Cart).HasForeignKey(fk => fk.CartId).OnDelete(DeleteBehavior.Cascade);
    }
}
