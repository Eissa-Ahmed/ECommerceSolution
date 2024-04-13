namespace Ecommerce.Core.Feature.SubCategoryFeature.Query.Validation;

public sealed class SubCategoryGetAllValidation : AbstractValidator<SubCategoryGetAllModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public SubCategoryGetAllValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        ApplyValidaion();
    }

    private void ApplyValidaion()
    {
        When(i => i.Id != null, () =>
        {
            RuleFor(i => i.Id!).MustAsync(CategoryExists).WithMessage("Category not found");
        });
    }

    private async Task<bool> CategoryExists(string arg1, CancellationToken token)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(arg1);
        return category != null;
    }
}
