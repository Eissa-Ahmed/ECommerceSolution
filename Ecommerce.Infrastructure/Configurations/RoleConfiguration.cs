namespace Ecommerce.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
        entity.ToTable("Roles");

        entity.Property(p => p.CreatedBy).IsRequired(true);

    }
}
