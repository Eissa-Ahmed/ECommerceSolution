namespace Ecommerce.Core.Feature.CategoryFeature.Query.Validation;

public sealed class CategoryGetByIdValidation : AbstractValidator<CategoryGetByIdModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryGetByIdValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        ApplyValidation();
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync(ExistCategory).WithMessage("Category not found");
    }

    private async Task<bool> ExistCategory(string arg1, CancellationToken token)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(arg1);
        return category != null;
    }
}
