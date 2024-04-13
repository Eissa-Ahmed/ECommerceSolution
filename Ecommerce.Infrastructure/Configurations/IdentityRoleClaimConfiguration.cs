namespace Ecommerce.Infrastructure.Configurations;

public class IdentityRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> entity)
    {
        entity.ToTable("RoleClaim");
    }
}
