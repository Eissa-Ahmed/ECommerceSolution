namespace Ecommerce.Core.Feature.UserFeature.Command.Validation;

public sealed class UserForgetPasswordValidation : AbstractValidator<UserForgetPasswordModel>
{
    private readonly UserManager<User> _userManager;
    public UserForgetPasswordValidation(UserManager<User> userManager)
    {
        ApplyValidation();
        _userManager = userManager;
    }

    private void ApplyValidation()
    {
        RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress()
            .MustAsync(ExistEmail).WithMessage("Email Not exist");

        RuleFor(i => i.Password).NotNull().NotEmpty().Length(6, 16)
            .Matches(@"^[A-Za-z1-9]+$").WithMessage("The string contains only A-Z, a-z, and 1-9 characters.");

        RuleFor(i => i.Code).NotNull().NotEmpty().Length(6);
    }

    private async Task<bool> ExistEmail(string arg1, CancellationToken token)
    {
        User? user = await _userManager.FindByEmailAsync(arg1);
        return user is not null;
    }
}
