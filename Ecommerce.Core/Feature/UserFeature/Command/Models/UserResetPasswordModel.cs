namespace Ecommerce.Core.Feature.UserFeature.Command.Models;

public sealed class UserResetPasswordModel : IRequest<Response<string>>
{
    public string Email { get; set; } = null!;
    public string OldPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
