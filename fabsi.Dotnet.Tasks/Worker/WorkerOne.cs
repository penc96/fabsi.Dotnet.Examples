
namespace fabsi.Dotnet.Tasks.Worker;

public class WorkerOne : WorkerBase
{
    public Task DoAsync(CancellationToken ct = default)
    {
        return Task.Run(async () =>
        {
            LogStart();
            LogProcessInfo();
            await Task.Delay(1000, ct);
            LogEnd();
        }, ct);
    }
}