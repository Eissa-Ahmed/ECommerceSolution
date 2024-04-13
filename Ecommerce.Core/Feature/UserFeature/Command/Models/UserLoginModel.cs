using MediatR;

namespace Ecommerce.Core.Feature.UserFeature.Command.Models;

/*public class UserLoginModel(string Email, string Password) : IRequest<Response<AuthenticationModel>>
{
    public string Email { get; set; } = Email;
    public string Password { get; set; } = Password;
}*/
public class UserLoginModel : IRequest<Response<AuthenticationModel>>
{
    public UserLoginModel(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}
