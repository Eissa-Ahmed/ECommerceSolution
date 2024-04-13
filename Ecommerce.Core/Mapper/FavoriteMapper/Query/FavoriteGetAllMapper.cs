namespace Ecommerce.Core.Mapper.FavoriteMapper;

public partial class FavoriteProfile
{
    private void ApplyFavoriteGetAllMapper()
    {
        CreateMap<Product, FavoriteGetAllResult>();
    }
}
