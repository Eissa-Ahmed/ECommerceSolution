namespace Ecommerce.Core.Feature.ProductFeature.Query.Validation;

public sealed class ProductGetInSubCategoryValidation : AbstractValidator<ProductGetInSubCategoryModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductGetInSubCategoryValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("SubCategory Id is required")
           .MustAsync(SubCategoryExist).WithMessage("SubCategory not found");
    }
    private async Task<bool> SubCategoryExist(string arg1, CancellationToken token)
    {
        var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(arg1);
        return subCategory != null;
    }
}
