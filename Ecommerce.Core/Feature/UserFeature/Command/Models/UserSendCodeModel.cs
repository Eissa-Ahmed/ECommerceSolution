namespace Ecommerce.Core.Feature.UserFeature.Command.Models;

public sealed class UserSendCodeModel(string Email) : IRequest<Response<string>>
{
    public string Email { get; set; } = Email;
}
