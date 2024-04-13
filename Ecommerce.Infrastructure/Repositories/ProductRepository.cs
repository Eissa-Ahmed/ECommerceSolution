
namespace Ecommerce.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly ApplicationDBContext _dbContext;
    public ProductRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetCountProductsAsync(string? SubCategoryId = null)
    {
        if (SubCategoryId == null)
        {
            int count = await _dbContext.Product.CountAsync();
            return count;
        }


        int productsCount = await _dbContext.Product.CountAsync(x => x.SubCategoryId == SubCategoryId);
        return productsCount;
    }
}
