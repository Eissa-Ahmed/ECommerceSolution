namespace Ecommerce.Services.Services;

public class CategoryServices : ICategoryServices
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<Category> GetAll()
    {
        var result = _unitOfWork.CategoryRepository.GetTableNoTracking().Include(x => x.SubCategory);
        return result.ToList();
    }
    public async Task<Category> AddAsync(Category category)
    {
        var result = await _unitOfWork.CategoryRepository.AddAsync(category);
        return result;
    }

    public async Task<string> DeleteAsync(string Id)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(Id);
        await _unitOfWork.CategoryRepository.DeleteAsync(category);
        return "success";
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        await _unitOfWork.CategoryRepository.UpdateAsync(category);
        return category;
    }

    public async Task<Category> GetByIdAsync(string Id)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(Id);
        return category;
    }
}
