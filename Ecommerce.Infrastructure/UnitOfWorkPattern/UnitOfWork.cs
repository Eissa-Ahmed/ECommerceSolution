
namespace Ecommerce.Infrastructure.UnitOfWorkPattern;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;
    public IProductRepository ProductRepository { get; private set; }

    public ICartItemRepository CartItemRepository { get; private set; }

    public ICartRepository CartRepository { get; private set; }

    public ICategoryRepository CategoryRepository { get; private set; }

    public ISubCategoryRepository SubCategoryRepository { get; private set; }

    public IFavoriteRepository FavoriteRepository { get; private set; }

    public IOrderDetailsRepository OrderDetailsRepository { get; private set; }

    public IOrderRepository OrderRepository { get; private set; }

    public IPaymentRepository PaymentRepository { get; private set; }

    public UnitOfWork(ApplicationDBContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(_context);
        CartItemRepository = new CartItemRepository(_context);
        CartRepository = new CartRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        SubCategoryRepository = new SubCategoryRepository(_context);
        FavoriteRepository = new FavoriteRepository(_context);
        OrderDetailsRepository = new OrderDetailsRepository(_context);
        OrderRepository = new OrderRepository(_context);
        PaymentRepository = new PaymentRepository(_context);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<IDbContextTransaction> BeginTransaction()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollBack()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}
