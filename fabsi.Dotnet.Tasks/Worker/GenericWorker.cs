namespace fabsi.Dotnet.Tasks.Worker;

public class GenericWorker : WorkerBase
{
    public int Id { get; }
    public int WaitTime { get; }
    public GenericWorker(int id, int waitTime)
    {
        Id = id;
        WaitTime = waitTime;
    }

    public async Task DoWorkAsync()
    {
        for (int i = 0; i < WaitTime; i++)
        {
            if (i % 100 == 0)
                LogProcessInfo();
            await Task.Delay(1);
        }
    }
}