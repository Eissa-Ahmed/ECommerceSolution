namespace Ecommerce.Core.Feature.FavoriteFeature.Command.Validation;

public sealed class FavoriteAddValidation : AbstractValidator<FavoriteAddModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public FavoriteAddValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        ApplyValidation();
    }

    private void ApplyValidation()
    {
        RuleFor(i => i.ProductId).NotEmpty().WithMessage("productId is required")
            .MustAsync(ProductExist).WithMessage("product not found");
    }

    private async Task<bool> ProductExist(string arg1, CancellationToken token)
    {
        Product? product = await _unitOfWork.ProductRepository.GetByIdAsync(arg1);
        return product != null;
    }
}
