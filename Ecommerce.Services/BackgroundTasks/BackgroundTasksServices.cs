namespace Ecommerce.Services.BackgroundTasks;

public sealed class BackgroundTasksServices : IBackgroundTasksServices
{
    private readonly ApplicationDBContext _context;
    public BackgroundTasksServices(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task RemoveLogsAfter7Days()
    {
        var logs = await _context.Logs.AsNoTracking().Where(x => x.TimeStamp!.Value.AddMinutes(5) < DateTime.Now).ToListAsync();
        if (logs.Count > 0)
        {
            _context.Logs.RemoveRange(logs);
            await _context.SaveChangesAsync();
        }
        //RecurringJob.RemoveIfExists(nameof(RemoveLogsAfter7Days));
    }
}
