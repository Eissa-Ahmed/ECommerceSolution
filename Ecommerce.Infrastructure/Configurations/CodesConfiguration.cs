namespace Ecommerce.Infrastructure.Configurations;

public class CodesConfiguration : IEntityTypeConfiguration<Codes>
{
    public void Configure(EntityTypeBuilder<Codes> entity)
    {
        entity.ToTable("Codes");

        entity.HasKey(k => k.Id);
        entity.Property(p => p.Id).ValueGeneratedOnAdd();
        entity.Property(p => p.Code).IsFixedLength().HasMaxLength(6);

        entity.HasOne(o => o.User).WithMany(m => m.Codes).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
