namespace Ecommerce.Data.Entities;

public sealed class Payment
{
    public string PaymentId { get; set; } = null!;
    public decimal Amount { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }

    // Foreign keys
    public string OrderId { get; set; } = null!;

    // Navigation properties
    public Order? Order { get; set; }
}
