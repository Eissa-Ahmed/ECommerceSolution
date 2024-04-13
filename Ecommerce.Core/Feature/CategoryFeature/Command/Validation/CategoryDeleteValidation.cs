
namespace Ecommerce.Core.Feature.CategoryFeature.Command.Validation;

public sealed class CategoryDeleteValidation : AbstractValidator<CategoryDeleteModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryDeleteValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        ApplyValidation();
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Id)
             .NotEmpty().WithMessage("Id is required")
             .MustAsync(ExistCategory).WithMessage("Category not found")
             .MustAsync(CategoryNotHasSubCategory).WithMessage(" Category has sub category");
    }

    private async Task<bool> CategoryNotHasSubCategory(string arg1, CancellationToken token)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(arg1);
        if (category == null) return false;
        return category.SubCategory.Count == 0;
    }

    private async Task<bool> ExistCategory(string arg1, CancellationToken token)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(arg1);
        return category != null;
    }
}
