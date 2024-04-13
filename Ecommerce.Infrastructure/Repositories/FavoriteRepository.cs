namespace Ecommerce.Infrastructure.Repositories;

public class FavoriteRepository : BaseRepository<Favorite>, IFavoriteRepository
{
    public FavoriteRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
