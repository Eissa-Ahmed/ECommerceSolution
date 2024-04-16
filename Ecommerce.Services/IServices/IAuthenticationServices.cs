namespace Ecommerce.Services.IServices;

public interface IAuthenticationServices
{
    public Task<AuthenticationModel> Login(string email, string password);
    public Task<string> Register(string FirstName, string LastName, string email, string password);
    public Task<string> ForgetPassword(string email, string NewPassword, string Code);
    public Task<string> ResetPassword(string email, string OldPassword, string NewPassword);
    public Task<string> SendCodeToChangePassword(string email);
    public string? GetUserIdFromToken();
}
