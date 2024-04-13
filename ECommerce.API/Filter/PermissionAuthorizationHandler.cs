using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.API.Filter;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    public PermissionAuthorizationHandler()
    {

    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        // TODO: Check Exist User Login

        if (context.User == null || !context.User.Identity!.IsAuthenticated)
        {
            return Task.CompletedTask;
        }
        bool canAccess = false;
        // Check if the user has the required permission claim
        if (requirement.Permission.Contains(','))
        {
            List<bool> allowed = new List<bool>();
            var Permissions = requirement.Permission.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var per in Permissions)
            {
                var item = context.User.Claims.Any(c => c.Type == "Permission" && c.Value == per.Trim());
                allowed.Add(item);
            }
            canAccess = allowed.Any(x => x == true);
        }
        else
        {
            canAccess = context.User.Claims.Any(c => c.Type == "Permission" && c.Value == requirement.Permission);
        }

        if (canAccess)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
