namespace Ecommerce.Infrastructure.SeedData;

public static class SeedPermissions
{
    public static async Task SeedAsync(RoleManager<Role> roleManager)
    {
        var roleAdmin = await roleManager.FindByNameAsync(Roles.Admin);
        if (roleAdmin is not null)
        {
            var cliams = await roleManager.GetClaimsAsync(roleAdmin);
            if (cliams.Count == 0)
            {
                foreach (var permission in Permissions.GetPermissions())
                {
                    await roleManager.AddClaimAsync(roleAdmin, permission);
                }
            }
        }
    }
}
