namespace Ecommerce.Data.Entities;

public sealed class Order
{
    public Order()
    {
        OrderDetails = new HashSet<OrderDetails>();
        OrderDate = DateTime.Now;
    }
    public string OrderId { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }

    // Foreign keys
    public string? PaymentId { get; set; }
    public string UserId { get; set; } = null!;

    // Navigation properties
    public User? User { get; set; }
    public Payment? Payment { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
}
