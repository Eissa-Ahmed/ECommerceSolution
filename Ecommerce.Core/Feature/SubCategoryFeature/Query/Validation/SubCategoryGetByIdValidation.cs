namespace Ecommerce.Core.Feature.SubCategoryFeature.Query.Validation;

public sealed class SubCategoryGetByIdValidation : AbstractValidator<SubCategoryGetByIdModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public SubCategoryGetByIdValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        ApplyValidaion();
    }

    private void ApplyValidaion()
    {
        RuleFor(i => i.Id!).NotEmpty().WithMessage("Id is required")
             .MustAsync(CategoryExists).WithMessage("SubCategory not found");
    }

    private async Task<bool> CategoryExists(string arg1, CancellationToken token)
    {
        var category = await _unitOfWork.SubCategoryRepository.GetByIdAsync(arg1);
        return category != null;
    }
}
