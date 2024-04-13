namespace Ecommerce.Infrastructure.SeedData;

public static class SeedRoles
{
    public static async Task SeedAsync(RoleManager<Role> roleManager)
    {
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new Role { Name = Roles.Admin, CreatedBy = "System", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            await roleManager.CreateAsync(new Role { Name = Roles.User, CreatedBy = "System", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
