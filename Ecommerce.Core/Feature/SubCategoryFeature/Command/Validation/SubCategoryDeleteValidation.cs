namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Validation;

public sealed class SubCategoryDeleteValidation : AbstractValidator<SubCategoryDeleteModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public SubCategoryDeleteValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("SubCategory Id is required")
            .Must(SubCategoryExist).WithMessage("SubCategory not found")
            .MustAsync(async (model, key, cancel) => await CheckSubCategoryNotContainsProducts(key)).WithMessage("SubCategory contains products");

    }

    private async Task<bool> CheckSubCategoryNotContainsProducts(string Id)
    {
        int productsCount = await _unitOfWork.ProductRepository.GetCountProductsAsync(Id);
        return productsCount == 0;
    }


    private bool SubCategoryExist(string arg1)
    {
        var subCategory = _unitOfWork.SubCategoryRepository.GetTableNoTracking(i => i.SubCategoryId == arg1).FirstOrDefault();
        return subCategory is not null;
    }
}
