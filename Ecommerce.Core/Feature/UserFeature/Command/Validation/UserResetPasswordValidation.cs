namespace Ecommerce.Core.Feature.UserFeature.Command.Validation;

public sealed class UserResetPasswordValidation : AbstractValidator<UserResetPasswordModel>
{
    private readonly UserManager<User> _userManager;
    public UserResetPasswordValidation(UserManager<User> userManager)
    {
        ApplyValidation();
        _userManager = userManager;
    }

    private void ApplyValidation()
    {
        RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress()
            .MustAsync(ExistEmail).WithMessage("Email Not exist");

        RuleFor(i => i.OldPassword).NotNull().NotEmpty();
        RuleFor(i => i.NewPassword).NotNull().NotEmpty();

    }

    private async Task<bool> ExistEmail(string arg1, CancellationToken token)
    {
        User? user = await _userManager.FindByEmailAsync(arg1);
        return user is not null;
    }
}
