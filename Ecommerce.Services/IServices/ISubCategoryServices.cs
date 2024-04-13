namespace Ecommerce.Services.IServices;

public interface ISubCategoryServices
{
    public IEnumerable<SubCategory> GetAll(string? categoryId = null);
    public Task<SubCategory> GetByIdAsync(string Id);
    public Task<SubCategory> AddAsync(SubCategory subCategory);
    public Task<SubCategory> UpdateAsync(SubCategory subCategory);
    public Task<string> RemoveAsync(string Id);
}
