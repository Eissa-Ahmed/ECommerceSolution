namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Validation;

public sealed class SubCategoryAddValidation : AbstractValidator<SubCategoryAddModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public SubCategoryAddValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name SubCategory is required")
             .Length(3, 50).WithMessage("Name SubCategory must be less than 50 characters and more than 3 characters")
             .Must((model, key, cancel) => !SubCategoryExist(name: key)).WithMessage("SubCategory already exist");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Id is required")
            .Must(CategoryExist).WithMessage("Category not found");

    }

    private bool CategoryExist(string arg1)
    {
        var category = _unitOfWork.CategoryRepository.GetTableNoTracking(i => i.CategoryId == arg1).FirstOrDefault();
        return category is not null;
    }

    private bool SubCategoryExist(string name)
    {
        var category = _unitOfWork.SubCategoryRepository.GetTableNoTracking(i => i.Name == name).FirstOrDefault();
        return category is null ? false : true;
    }
}
