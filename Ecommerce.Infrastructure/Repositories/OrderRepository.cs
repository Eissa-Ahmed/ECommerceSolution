namespace Ecommerce.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
