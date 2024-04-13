namespace Ecommerce.Infrastructure.Repositories.IRepositories;

public interface IProductRepository : IBaseRepository<Product>
{
    public Task<int> GetCountProductsAsync(string? SubCategoryId = null);
}

