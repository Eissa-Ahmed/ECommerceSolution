namespace Ecommerce.Core.Feature.UserFeature.Command.Validation;

public sealed class UserSendCodeValidation : AbstractValidator<UserSendCodeModel>
{
    private readonly UserManager<User> _userManager;
    public UserSendCodeValidation(UserManager<User> userManager)
    {
        ApplyValidation();
        _userManager = userManager;
    }

    private void ApplyValidation()
    {
        RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress()
            .MustAsync(ExistEmail).WithMessage("Email Not exist");
    }

    private async Task<bool> ExistEmail(string arg1, CancellationToken token)
    {
        User? user = await _userManager.FindByEmailAsync(arg1);
        return user is not null;
    }
}
