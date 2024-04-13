namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Validation;

public sealed class SubCategoryUpdateValidation : AbstractValidator<SubCategoryUpdateModel>
{
    private readonly IUnitOfWork _unitOfWork;
    public SubCategoryUpdateValidation(IUnitOfWork unitOfWork)
    {
        ApplyValidation();
        _unitOfWork = unitOfWork;
    }

    private void ApplyValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name SubCategory is required")
             .Length(3, 50).WithMessage("Name SubCategory must be less than 50 characters and more than 3 characters")
             .Must((model, key, cancel) => !SubCategoryNameExistButExceptHimself(model: model)).WithMessage("SubCategory already exist");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Id is required")
            .Must(CategoryExist).WithMessage("Category not found");

    }

    private bool CategoryExist(string arg1)
    {
        var category = _unitOfWork.CategoryRepository.GetTableNoTracking(i => i.CategoryId == arg1).FirstOrDefault();
        return category is not null;
    }

    private bool SubCategoryNameExistButExceptHimself(SubCategoryUpdateModel model)
    {
        var category = _unitOfWork.SubCategoryRepository.GetTableNoTracking(i => i.Name == model.Name && i.SubCategoryId != model.SubCategoryId).FirstOrDefault();
        return category is null ? false : true;
    }
}
