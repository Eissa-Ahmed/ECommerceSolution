namespace Ecommerce.Infrastructure.Repositories;

public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(ApplicationDBContext dBContext) : base(dBContext) { }
}
