namespace Ecommerce.Services.IServices;

public interface IProductServices
{
    public Task<(List<Product> products, int pageCount)> GetAllProductAsync(int pageNumber, string? subCategoryId = null, Expression<Func<Product, bool>>? filter = null);
    public Task<Product> GetByIdAsync(string productId);
    public Task<(Product, string)> addProductAsync(Product product, IFormFile Image);
    public Task<string> DeleteProductAsync(string productId);
    public Task<Product> UpdateProductAsync(Product product, IFormFile? formFile = null);

}
