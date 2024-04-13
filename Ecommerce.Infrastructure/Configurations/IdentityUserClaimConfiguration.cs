namespace Ecommerce.Infrastructure.Configurations;

public class IdentityUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> entity)
    {
        entity.ToTable("UserClaim");
    }
}
