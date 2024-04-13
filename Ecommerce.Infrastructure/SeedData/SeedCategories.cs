namespace Ecommerce.Infrastructure.SeedData;

public static class SeedCategories
{
    public static async Task SeedAsync(ApplicationDBContext dBContext)
    {
        var categories = await dBContext.Category.ToListAsync();
        if (!categories.Any())
        {
            await dBContext.Category.AddRangeAsync(getCategories());
            await dBContext.SaveChangesAsync();
        }
    }
    private static List<Category> getCategories()
    {
        return new List<Category>(){
            new Category { Name = "Men's Clothing", SubCategory = getSubCategoriesMen()},
            new Category { Name = "Women's Clothing", SubCategory = getSubCategoriesWoman()}
        };
    }
    private static List<SubCategory> getSubCategoriesMen()
    {
        return new List<SubCategory>(){
            new SubCategory { Name = "T-Shirts"},
            new SubCategory { Name = "Shirts"},
            new SubCategory { Name = "Polo Shirts"},
            new SubCategory { Name = "Sweatshirts & Hoodies"},
            new SubCategory { Name = "Jeans"},
            new SubCategory { Name = "Pants"},
            new SubCategory { Name = "Shorts"},
            new SubCategory { Name = "Swimwear"},
            new SubCategory { Name = "Jackets"},
            new SubCategory { Name = "Coats"},
            new SubCategory { Name = "Blazers"},
            new SubCategory { Name = "Vests"},
            new SubCategory { Name = "Sports Jerseys"},
            new SubCategory { Name = "Tracksuits"},
            new SubCategory { Name = "Workout Tops"},
            new SubCategory { Name = "Workout Bottoms"},
            new SubCategory { Name = "Suits"},
            new SubCategory { Name = "Suit Separates"},
            new SubCategory { Name = "Boxers & Briefs"},
            new SubCategory { Name = "Socks"},
            new SubCategory { Name = "Undershirts"}
        };
    }
    private static List<SubCategory> getSubCategoriesWoman()
    {
        return new List<SubCategory>(){
            new SubCategory { Name = "Blouses & Shirts"},
            new SubCategory { Name = "T-Shirts & Tank Tops"},
            new SubCategory { Name = "Sweaters & Cardigans"},
            new SubCategory { Name = "Tunics"},
            new SubCategory { Name = "Casual Dresses"},
            new SubCategory { Name = "Evening Dresses"},
            new SubCategory { Name = "Cocktail Dresses"},
            new SubCategory { Name = "Maxi Dresses"},
            new SubCategory { Name = "Jeans"},
            new SubCategory { Name = "Pants & Leggings"},
            new SubCategory { Name = "Skirts"},
            new SubCategory { Name = "Shorts"},
            new SubCategory { Name = "Jackets & Coats"},
            new SubCategory { Name = "Blazers"},
            new SubCategory { Name = "Vests"},
            new SubCategory { Name = "Ponchos & Capes"},
            new SubCategory { Name = "Sports Bras"},
            new SubCategory { Name = "Yoga Pants & Leggings"},
            new SubCategory { Name = "Athletic Tops"},
            new SubCategory { Name = "Workout Jackets"},
            new SubCategory { Name = "Pantsuits"},
            new SubCategory { Name = "Skirt Suits"},
            new SubCategory { Name = "Coordinates Sets"},
            new SubCategory { Name = "Bras & Bralettes"},
            new SubCategory { Name = "Panties & Thongs"},
            new SubCategory { Name = "Shapewear"},
            new SubCategory { Name = "Lingerie Sets"}
        };
    }
}
