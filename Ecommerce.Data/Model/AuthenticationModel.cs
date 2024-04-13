namespace Ecommerce.Data.Model;

public class AuthenticationModel
{
    public bool IsAuthenticated { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }
    public DateTime ExpiresOn { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiresOn { get; set; }
}