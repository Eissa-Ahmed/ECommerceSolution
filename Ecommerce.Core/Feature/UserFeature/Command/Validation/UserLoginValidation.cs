namespace Ecommerce.Core.Feature.UserFeature.Command.Validation;

public class UserLoginValidation : AbstractValidator<UserLoginModel>
{
    private readonly UserManager<User> _userManager;
    public UserLoginValidation(UserManager<User> userManager)
    {
        ApplyValidation();
        _userManager = userManager;
    }
    private void ApplyValidation()
    {
        RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(i => i.Password).NotNull().NotEmpty();
        RuleFor(i => i)
            .MustAsync(async (model, key, cancel) => await CheckEmailOrPassword(model.Email, model.Password))
            .WithName("SignIn")
            .WithMessage("Email Or Password InCorrect");
    }

    private async Task<bool> CheckEmailOrPassword(string email, string password)
    {
        User? user = await _userManager.FindByEmailAsync(email);
        if (user is null) return false;
        var result = await _userManager.CheckPasswordAsync(user, password);
        return result;
    }
}
