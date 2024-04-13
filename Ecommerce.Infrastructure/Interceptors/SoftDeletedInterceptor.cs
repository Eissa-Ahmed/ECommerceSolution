
namespace Ecommerce.Data.Entities;

public class SoftDeletedInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            /*if (entry is null)
                continue;
            if (entry.State != EntityState.Deleted)
                continue;
            if (entry is not ISoftDelete entity)
                continue;*/
            if (entry is null || entry.State != EntityState.Deleted || entry.Entity is not ISoftDelete entity)
                continue;

            entry.State = EntityState.Modified;
            entity.SoftDelete();
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
