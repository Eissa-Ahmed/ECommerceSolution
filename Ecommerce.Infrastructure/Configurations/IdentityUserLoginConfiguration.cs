namespace Ecommerce.Infrastructure.Configurations;

public class IdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> entity)
    {
        entity.ToTable("UserLogin");
    }
}
