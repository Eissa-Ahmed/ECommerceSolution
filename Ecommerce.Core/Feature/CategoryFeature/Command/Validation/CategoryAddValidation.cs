namespace Ecommerce.Core.Feature.CategoryFeature.Command.Validation;

public sealed class CategoryAddValidation : AbstractValidator<CategoryAddModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryAddValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Category is required")
             .Length(3, 50).WithMessage("Name Category must be less than 50 characters and more than 3 characters")
             .Must((model, key, cancel) => !CategoryExist(name: key)).WithMessage("Category already exist");
        When(i => i.subCategory is not null, () =>
        {
            RuleForEach(x => x.subCategory).SetValidator(new SubCategoryAddValidation())
            .WithName("SubCategory");
        });
    }

    private bool CategoryExist(string name)
    {
        var category = _unitOfWork.CategoryRepository.GetTableNoTracking(i => i.Name == name).FirstOrDefault();
        return category is null ? false : true;
    }
}

internal sealed class SubCategoryAddValidation : AbstractValidator<CategoryAddModelSubCategory>
{
    public SubCategoryAddValidation()
    {
        ApplyValidation();
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name SubCategory is required")
            .Length(3, 50).WithMessage("Name SubCategory must be less than 50 characters and more than 3 characters");
    }
}