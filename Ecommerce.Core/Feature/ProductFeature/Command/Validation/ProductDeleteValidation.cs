
namespace Ecommerce.Core.Feature.ProductFeature.Command.Validation;

public sealed class ProductDeleteValidation : AbstractValidator<ProductDeleteModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductDeleteValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id is required")
            .MustAsync(ProductExist).WithMessage("Product not found");
    }

    private async Task<bool> ProductExist(string arg1, CancellationToken token)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(arg1);
        return product != null;
    }
}

