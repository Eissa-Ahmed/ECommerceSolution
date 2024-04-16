namespace Ecommerce.Core.Feature.UserFeature.Command.Models;

public sealed class UserForgetPasswordModel : IRequest<Response<string>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Code { get; set; } = null!;
}
