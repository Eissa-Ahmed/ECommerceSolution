namespace Ecommerce.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("Users");

        entity.Property(p => p.FirstName).IsRequired(true).HasMaxLength(50);
        entity.Property(p => p.LastName).IsRequired(true).HasMaxLength(50);

        entity.HasMany(m => m.Orders).WithOne(o => o.User).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(m => m.Carts).WithOne(o => o.User).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(m => m.Favorites).WithOne(o => o.User).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
