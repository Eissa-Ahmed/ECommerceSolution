namespace Ecommerce.Services.IServices;

public interface IAuthenticationServices
{
    public Task<AuthenticationModel> Login(string email, string password);
    public Task<string> Register(string FirstName, string LastName, string email, string password);
    public string? GetUserIdFromToken();
}
