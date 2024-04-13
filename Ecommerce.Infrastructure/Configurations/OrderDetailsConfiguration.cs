namespace Ecommerce.Infrastructure.Configurations;

public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> entity)
    {
        entity.ToTable("OrderDetails");
        entity.HasKey(k => k.OrderDetailsId);

        entity.Property(p => p.OrderDetailsId).ValueGeneratedOnAdd();
    }
}
