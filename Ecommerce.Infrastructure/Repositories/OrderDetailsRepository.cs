namespace Ecommerce.Infrastructure.Repositories;

public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
