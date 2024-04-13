namespace Ecommerce.Infrastructure.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.ToTable("Category");
        entity.HasKey(k => k.CategoryId);
        entity.Property(p => p.CategoryId).ValueGeneratedOnAdd();
        entity.Property(p => p.Name).IsRequired(true).HasMaxLength(50);

        entity.HasMany(m => m.SubCategory).WithOne(o => o.Category).HasForeignKey(fk => fk.CategoryId).OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(m => m.Products).WithOne(o => o.Category).HasForeignKey(fk => fk.CategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}
