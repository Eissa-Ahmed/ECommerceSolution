namespace Ecommerce.Infrastructure.Configurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> entity)
    {
        entity.ToTable("Favorite");
        entity.HasKey(k => k.FavoriteId);
        entity.Property(p => p.FavoriteId).ValueGeneratedOnAdd();
    }
}
