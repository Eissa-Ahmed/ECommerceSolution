namespace Ecommerce.Core.Mapper.FavoriteMapper;

public partial class FavoriteProfile : Profile
{
    public FavoriteProfile()
    {
        ApplyFavoriteAddMapper();
        ApplyFavoriteGetAllMapper();
    }
}
