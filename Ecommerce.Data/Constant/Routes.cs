namespace Ecommerce.Data.Constant;

public static class Routes
{
    private const string Base = "api/";

    public struct Product
    {
        public const string GetAll = Base + "products";
        public const string GetAllInSubCategory = Base + "products/{subCategoryId}";
        public const string Get = Base + "products/{id}";
        public const string Create = Base + "products";
        public const string Update = Base + "products/{id}";
        public const string Delete = Base + "products/{id}";
    }
    public struct Category
    {
        public const string GetAll = Base + "Categories";
        public const string Get = Base + "Categories/{id}";
        public const string Create = Base + "Categories";
        public const string Update = Base + "Categories/{id}";
        public const string Delete = Base + "Categories/{id}";
    }
    public struct SubCategory
    {
        public const string GetAll = Base + "SubCategories";
        public const string Get = Base + "SubCategories/{id}";
        public const string Create = Base + "SubCategories";
        public const string Update = Base + "SubCategories/{id}";
        public const string Delete = Base + "SubCategories/{id}";
    }
    public struct Favorite
    {
        public const string GetAll = Base + "Favorite";
        public const string Get = Base + "Favorite/{id}";
        public const string Create = Base + "Favorite";
        public const string Update = Base + "Favorite/{id}";
        public const string Delete = Base + "Favorite/{id}";
    }
    public struct User
    {
        public const string Login = Base + "Login";
        public const string Register = Base + "Register";

    }
}
