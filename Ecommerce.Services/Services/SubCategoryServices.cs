namespace Ecommerce.Services.Services;

public sealed class SubCategoryServices : ISubCategoryServices
{
    private readonly IUnitOfWork _unitOfWork;
    public SubCategoryServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<SubCategory> GetAll(string? categoryId = null)
    {
        if (categoryId is null)
        {
            var result = _unitOfWork.SubCategoryRepository.GetTableNoTracking();
            return result.ToList();
        }
        else
        {
            var result = _unitOfWork.SubCategoryRepository.GetTableNoTracking().Where(x => x.CategoryId == categoryId);
            return result.ToList();
        }
    }
    public async Task<SubCategory> GetByIdAsync(string Id)
    {
        var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(Id);
        return subCategory;
    }
    public async Task<SubCategory> AddAsync(SubCategory subCategory)
    {
        //var category = _unitOfWork.CategoryRepository.GetTableAsTracking(i => i.CategoryId == categoryId).FirstOrDefault();
        //category!.SubCategory.Add(subCategory);
        //await _unitOfWork.Save();
        var result = await _unitOfWork.SubCategoryRepository.AddAsync(subCategory);
        return result;
    }
    public async Task<SubCategory> UpdateAsync(SubCategory subCategory)
    {
        await _unitOfWork.SubCategoryRepository.UpdateAsync(subCategory);
        return subCategory;
    }
    public async Task<string> RemoveAsync(string Id)
    {
        var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(Id);
        await _unitOfWork.SubCategoryRepository.DeleteAsync(subCategory);
        return "Success";
    }

}
