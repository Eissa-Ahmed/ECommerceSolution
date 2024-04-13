using Ecommerce.Data.Constant;

namespace Ecommerce.Services.Services;

public class AuthenticationServices : IAuthenticationServices
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IEmailServices _emailServices;
    private readonly IUnitOfWork _unitOfWork;
    private readonly Jwt _jwt;
    public AuthenticationServices(UserManager<User> userManager, Jwt jwt, RoleManager<Role> roleManager, IHttpContextAccessor httpContextAccessor, IEmailServices emailServices, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _jwt = jwt;
        _roleManager = roleManager;
        _httpContextAccessor = httpContextAccessor;
        _emailServices = emailServices;
        _unitOfWork = unitOfWork;
    }


    public async Task<AuthenticationModel> Login(string email, string password)
    {
        User? user = await _userManager.FindByEmailAsync(email);
        var authenticationModel = new AuthenticationModel();
        authenticationModel.IsAuthenticated = true;
        authenticationModel.Email = email;
        authenticationModel.UserName = user!.UserName;
        authenticationModel.ExpiresOn = DateTime.UtcNow.AddMinutes(_jwt.ExpireMinutes);
        authenticationModel.Token = GenerateToken(user).Result;

        return authenticationModel;
    }
    public async Task<string> Register(string FirstName, string LastName, string email, string password)
    {
        await _unitOfWork.BeginTransaction();

        try
        {
            User user = new User { FirstName = FirstName, LastName = LastName, Email = email, UserName = email.Substring(0, email.IndexOf('@')) };
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(",", result.Errors.Select(x => x.Description)));
            }

            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, Roles.User);
            if (!roleResult.Succeeded)
            {
                throw new Exception(string.Join(",", roleResult.Errors.Select(x => x.Description)));
            }
            await _emailServices.SendEmail(user.Email, "Welcome", "Welcome to Ecommerce");

            await _unitOfWork.Commit();
            return "Success";
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollBack();
            return ex.Message;
        }

    }
    public string? GetUserIdFromToken()
    {
        string? token = getTokenFromHeader();
        if (token is null)
            return null;

        bool IsValid = tokenIsValid(token, out ClaimsPrincipal claimsPrincipal);
        if (!IsValid) return null;

        return claimsPrincipal.FindFirst("uid")?.Value;
    }



    // Private Methods
    private bool tokenIsValid(string token, out ClaimsPrincipal claimsPrincipal)
    {
        var handler = new JwtSecurityTokenHandler();
        TokenValidationParameters validationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwt.Issuer,
            ValidAudience = _jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
            ClockSkew = TimeSpan.FromMinutes(_jwt.ExpireMinutes)
        };
        claimsPrincipal = handler.ValidateToken(token, validationParameters, out _);
        return claimsPrincipal != null;
    }
    private string? getTokenFromHeader()
    {
        if (_httpContextAccessor.HttpContext!.Request.Headers.TryGetValue("Authorization", out var accessToken))
            return accessToken.ToString().Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);
        return null;
    }
    private async Task<string> GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var securityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: await getClaims(user),
            expires: DateTime.UtcNow.AddMinutes(_jwt.ExpireMinutes),
            signingCredentials: signingCredentials
            );

        return handler.WriteToken(securityToken);
    }
    private async Task<IEnumerable<Claim>> getClaims(User user)
    {
        var claimsUser = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        List<Claim> claimsRole = new List<Claim>();

        foreach (var role in roles)
        {
            var getRole = await _roleManager.FindByNameAsync(role);
            var claimForSignalRole = await _roleManager.GetClaimsAsync(getRole!);
            claimsRole.AddRange(claimForSignalRole);
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", user.Id.ToString()),
        }
        .Union(claimsUser)
        .Union(claimsRole).ToList();
        for (int i = 0; i < roles.Count(); i++)
        {
            claims.Add(new Claim("Role", roles[i]));
        }
        return claims;
    }

}
