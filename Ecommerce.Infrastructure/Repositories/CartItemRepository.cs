namespace Ecommerce.Infrastructure.Repositories;

public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
