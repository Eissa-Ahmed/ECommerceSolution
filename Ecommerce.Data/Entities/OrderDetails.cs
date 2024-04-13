namespace Ecommerce.Data.Entities;

public sealed class OrderDetails
{
    public string OrderDetailsId { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    // Foreign keys
    public string OrderId { get; set; } = null!;
    public string ProductId { get; set; } = null!;

    // Navigation properties
    public Order? Order { get; set; }
    public Product? Product { get; set; }
}
