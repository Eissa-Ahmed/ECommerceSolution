namespace Ecommerce.Data.Constant;

public static class Permissions
{
    public static List<Claim> GetPermissions()
    {
        return new List<Claim>()
        {
            //Product
            new Claim("Permission", "CreateProduct"),
            new Claim("Permission", "DeleteProduct"),
            new Claim("Permission", "UpdateProduct"),
            new Claim("Permission", "ViewProduct"),

            //Roles
            new Claim("Permission", "CreateRole"),
            new Claim("Permission", "DeleteRole"),
            new Claim("Permission", "UpdateRole"),
            new Claim("Permission", "ViewRole"),
        };
    }
}
