namespace Ecommerce.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.ToTable("Order");
        entity.HasKey(k => k.OrderId);

        entity.Property(p => p.OrderId).ValueGeneratedOnAdd();
        entity.Property(p => p.Status).HasConversion(v => v.ToString(), v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

        entity.HasMany(m => m.OrderDetails).WithOne(o => o.Order).HasForeignKey(fk => fk.OrderId).OnDelete(DeleteBehavior.Cascade);
        entity.HasOne(o => o.Payment).WithOne(o => o.Order).HasForeignKey<Order>(fk => fk.PaymentId).OnDelete(DeleteBehavior.Restrict);

    }
}
