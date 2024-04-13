namespace Ecommerce.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("Product");
        entity.HasKey(k => k.ProductId);
        entity.Property(p => p.ProductId).ValueGeneratedOnAdd();
        entity.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
        entity.Property(p => p.Description).IsRequired(true).HasMaxLength(500);

        entity.HasMany(m => m.CartItems).WithOne(o => o.Product).HasForeignKey(fk => fk.ProductId).OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(m => m.OrderDetails).WithOne(o => o.Product).HasForeignKey(fk => fk.ProductId).OnDelete(DeleteBehavior.Cascade);
    }
}
