namespace Ecommerce.Infrastructure.UnitOfWorkPattern;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository ProductRepository { get; }
    public ICartItemRepository CartItemRepository { get; }
    public ICartRepository CartRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ISubCategoryRepository SubCategoryRepository { get; }
    public IFavoriteRepository FavoriteRepository { get; }
    public IOrderDetailsRepository OrderDetailsRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IPaymentRepository PaymentRepository { get; }
    public Task Save();
    public Task<IDbContextTransaction> BeginTransaction();
    public Task Commit();
    public Task RollBack();
}
