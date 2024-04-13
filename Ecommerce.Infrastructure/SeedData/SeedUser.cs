namespace Ecommerce.Infrastructure.SeedData;

public static class SeedUser
{
    public static async Task SeedAsync(UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new User
            {
                FirstName = "admin",
                LastName = "",
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };
            await userManager.CreateAsync(user, "Es123456");
            //user = await userManager.FindByEmailAsync("admin@gmail.com");
            //await userManager.AddToRoleAsync(user!, Roles.Admin);
            await userManager.AddToRolesAsync(user, new[] { Roles.Admin, Roles.User });
        }
    }
}
