namespace Ecommerce.Core.Feature.UserFeature.Command.Validation;

public sealed class UserRegisterValidation : AbstractValidator<UserRegisterModel>
{
    private readonly UserManager<User> _userManager;
    public UserRegisterValidation(UserManager<User> userManager)
    {
        _userManager = userManager;
        ApplyValidation();
    }

    private void ApplyValidation()
    {
        RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress()
            .MustAsync(ExistNotEmail).WithMessage("Email already exist");
        RuleFor(i => i.Password).NotNull().NotEmpty().Length(6, 16);
        RuleFor(i => i.FirstName).NotNull().NotEmpty();
        RuleFor(i => i.LastName).NotNull().NotEmpty();
    }

    private async Task<bool> ExistNotEmail(string arg1, CancellationToken token)
    {

        User? user = await _userManager.FindByEmailAsync(arg1);
        return user is null;
    }
}
