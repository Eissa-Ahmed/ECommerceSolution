namespace Ecommerce.Services.IServices;

public interface IFavoriteServices
{
    public Task<Favorite> AddAsync(string productId);
    public IEnumerable<Product> GetAllAsync();
    public Task<string> RemoveAsync(string favoriteId);


}
