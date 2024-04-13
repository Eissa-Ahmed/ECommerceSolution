namespace Ecommerce.Core.Feature.ProductFeature.Command.Validation;

public sealed class ProductAddValidation : AbstractValidator<ProductAddModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductAddValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 50).WithMessage("Name must be less than 50 characters and more than 3 characters");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
            .Length(3, 500).WithMessage("Description must be less than 500 characters and more than 3 characters");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required")
            .GreaterThanOrEqualTo(1).WithMessage("Price must be greater than 0");
        RuleFor(x => x.StockQuantity).NotEmpty().WithMessage("Stock is required")
            .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than Or Equal 0");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Id is required")
            .MustAsync(CategoryExist).WithMessage("Category not found");
        RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("SubCategory Id is required")
            .MustAsync(SubCategoryExist).WithMessage("SubCategory not found");

    }

    private async Task<bool> SubCategoryExist(string arg1, CancellationToken token)
    {
        var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(arg1);
        return subCategory != null;
    }

    private async Task<bool> CategoryExist(string arg1, CancellationToken token)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(arg1);
        return category != null;
    }
}
