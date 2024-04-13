namespace Ecommerce.Services.IServices;

public interface ICategoryServices
{
    public IEnumerable<Category> GetAll();
    public Task<Category> GetByIdAsync(string Id);
    public Task<Category> AddAsync(Category category);
    public Task<Category> UpdateAsync(Category category);
    public Task<string> DeleteAsync(string Id);
}
