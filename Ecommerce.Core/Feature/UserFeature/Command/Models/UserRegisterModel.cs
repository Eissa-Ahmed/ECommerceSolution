namespace Ecommerce.Core.Feature.UserFeature.Command.Models;

public sealed class UserRegisterModel : IRequest<Response<string>>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
