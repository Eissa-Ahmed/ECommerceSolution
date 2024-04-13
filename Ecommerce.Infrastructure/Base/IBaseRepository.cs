namespace Ecommerce.Infrastructure.Base;

public interface IBaseRepository<T> where T : class
{
    Task DeleteRangeAsync(ICollection<T> entities);
    Task<T> GetByIdAsync(string id);
    Task SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
    IQueryable<T> GetTableNoTracking(Expression<Func<T, bool>>? filter = null);
    IQueryable<T> GetTableAsTracking(Expression<Func<T, bool>>? filter = null);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(ICollection<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(ICollection<T> entities);
    Task DeleteAsync(T entity);

    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollBackAsync();
}
