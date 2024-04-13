

namespace Ecommerce.Core.Feature.CategoryFeature.Command.Validation
{
    public sealed class CategoryUpdateValidation : AbstractValidator<CategoryUpdateModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryUpdateValidation(IUnitOfWork unitOfWork)
        {
            ApplyValidation();
            _unitOfWork = unitOfWork;
        }

        private void ApplyValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required")
                 .Must((model, key, cancel) => CategoryExist(Id: key)).WithMessage("Category not exist");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Category is required")
                 .Length(3, 50).WithMessage("Name Category must be less than 50 characters and more than 3 characters")
                 .Must((model, key, cancel) => CategoryExistByNameExceptHimself(model.Name, model.Id))
                 .WithMessage("Category already exist, Name Category is not unique");
        }

        private bool CategoryExistByNameExceptHimself(string name, string Id)
        {
            var category = _unitOfWork.CategoryRepository.GetTableNoTracking(i => i.Name == name && i.CategoryId != Id).FirstOrDefault();
            return category is null;
        }

        private bool CategoryExist(string Id)
        {
            var category = _unitOfWork.CategoryRepository.GetTableNoTracking(i => i.CategoryId == Id).FirstOrDefault();
            return category is null ? false : true;
        }
    }
}
