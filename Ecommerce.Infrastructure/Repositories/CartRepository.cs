namespace Ecommerce.Infrastructure.Repositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
