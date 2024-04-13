namespace Ecommerce.Services.Email;

public interface IEmailServices
{
    public Task<string> SendEmail(string sendTo, string message, string subject);
}
