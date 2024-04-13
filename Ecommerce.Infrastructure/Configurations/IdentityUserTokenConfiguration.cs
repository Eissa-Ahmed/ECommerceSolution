namespace Ecommerce.Infrastructure.Configurations;

public class IdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> entity)
    {
        entity.ToTable("UserToken");
    }
}
