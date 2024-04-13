namespace Ecommerce.Infrastructure.Configurations;

public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> entity)
    {
        entity.ToTable("UserRole");
    }
}
