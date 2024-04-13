namespace Ecommerce.Services.IServices;

public interface ICartServices
{
    public Task<string> AddToCart(string productId);
    public Task<string> DeleteFromCart(string productId);
}
