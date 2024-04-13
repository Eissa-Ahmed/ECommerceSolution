namespace Ecommerce.Infrastructure.Configurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> entity)
    {
        entity.ToTable("SubCategory");
        entity.HasKey(k => k.SubCategoryId);
        entity.Property(p => p.SubCategoryId).ValueGeneratedOnAdd();
        entity.Property(p => p.Name).IsRequired(true).HasMaxLength(50);

        entity.HasMany(m => m.Products).WithOne(o => o.SubCategory).HasForeignKey(fk => fk.SubCategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}
