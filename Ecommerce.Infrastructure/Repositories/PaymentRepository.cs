namespace Ecommerce.Infrastructure.Repositories;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
