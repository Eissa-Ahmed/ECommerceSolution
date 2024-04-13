namespace Ecommerce.Core.Feature.FavoriteFeature.Command.Validation;

public sealed class FavoriteRemoveValidation : AbstractValidator<FavoriteRemoveModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public FavoriteRemoveValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        ApplyValidation();
    }

    private void ApplyValidation()
    {
        RuleFor(i => i.favoriteId).NotEmpty().WithMessage("favoriteId is required")
            .MustAsync(FavoriteExist).WithMessage("favorite not found");
    }

    private async Task<bool> FavoriteExist(string arg1, CancellationToken token)
    {
        Favorite? favorite = await _unitOfWork.FavoriteRepository.GetByIdAsync(arg1);
        return favorite != null;
    }
}
