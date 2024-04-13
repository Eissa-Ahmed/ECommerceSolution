namespace Ecommerce.Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity.ToTable("Payment");
        entity.HasKey(k => k.PaymentId);
        entity.Property(p => p.PaymentId).ValueGeneratedOnAdd();

        entity.HasOne(o => o.Order).WithOne(o => o.Payment).HasForeignKey<Payment>(fk => fk.OrderId).OnDelete(DeleteBehavior.Restrict);
    }
}