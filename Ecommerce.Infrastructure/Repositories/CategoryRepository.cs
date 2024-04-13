namespace Ecommerce.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDBContext _dbContext;
    public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public override async Task<Category> GetByIdAsync(string id)
    {
        //var x = await _dbContext.Logs.ToListAsync();
        var entity = await _dbContext.Category.AsNoTracking().Include(x => x.SubCategory)
            .FirstOrDefaultAsync(x => x.CategoryId == id);
        return entity;
    }
}
