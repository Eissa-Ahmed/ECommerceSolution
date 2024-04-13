namespace Ecommerce.Core.Mapper.FavoriteMapper;


public partial class FavoriteProfile
{
    private void ApplyFavoriteAddMapper()
    {
        CreateMap<Favorite, FavoriteAddResult>();
    }
}
