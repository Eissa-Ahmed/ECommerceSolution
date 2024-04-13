namespace Ecommerce.Services.BackgroundTasks;

public interface IBackgroundTasksServices
{
    public Task RemoveLogsAfter7Days();
}
