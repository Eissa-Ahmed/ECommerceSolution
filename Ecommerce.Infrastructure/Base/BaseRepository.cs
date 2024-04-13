namespace Ecommerce.Infrastructure.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDBContext _dbContext;
    public BaseRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public virtual async Task<T> GetByIdAsync(string id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        return entity!;
    }
    public IQueryable<T> GetTableNoTracking(Expression<Func<T, bool>>? filter = null)
    {
        if (filter is null)
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        else
            return _dbContext.Set<T>().AsNoTracking().AsQueryable().Where(filter);
    }
    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();

    }
    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();

    }
    public virtual async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    public virtual async Task DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public IDbContextTransaction BeginTransaction()
    {
        return _dbContext.Database.BeginTransaction();
    }
    public void Commit()
    {
        _dbContext.Database.CommitTransaction();

    }
    public void RollBack()
    {
        _dbContext.Database.RollbackTransaction();
    }
    public IQueryable<T> GetTableAsTracking(Expression<Func<T, bool>>? filter = null)
    {
        if (filter is null)
            return _dbContext.Set<T>().AsQueryable();
        else
            return _dbContext.Set<T>().AsQueryable().Where(filter);
    }
    public virtual async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _dbContext.Database.BeginTransactionAsync();
    }
    public async Task CommitAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }
    public async Task RollBackAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}
