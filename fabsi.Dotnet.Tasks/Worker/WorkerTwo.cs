namespace fabsi.Dotnet.Tasks.Worker;

public class WorkerTwo : WorkerBase
{
    public Task DoAsync(CancellationToken ct = default)
    {
        return Task.Run(async () =>
        {
            LogStart();
            LogProcessInfo();
            await Task.Delay(5000, ct);
            LogEnd();
        }, ct);
    }
}