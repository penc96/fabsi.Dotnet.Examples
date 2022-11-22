
using fabsi.Dotnet.Tasks.Worker;
using System.Diagnostics;
using System.Threading.Channels;

var main = new Main();
// main.SimpleWorkerExample();
await main.MultipleWorkerExampleAsync(100);
Console.ReadKey();

class Main
{
    public void SimpleWorkerExample()
    {
        LogStart(nameof(SimpleWorkerExample));
        var one = new WorkerOne();
        var two = new WorkerTwo();

        var taskOne = one.DoAsync();
        var taskTwo = two.DoAsync();

        Task.WaitAny(taskOne, taskTwo);
        LogEnd(nameof(SimpleWorkerExample));
    }

    public async Task MultipleWorkerExampleAsync(int workerCount)
    {
        LogStart(nameof(MultipleWorkerExampleAsync));
        LogThreadCount();
        LogCPUCount();
        var workers = new List<Task>();
        for (int i = 1; i <= workerCount; i++)
            workers.Add(new GenericWorker(i, (i * 1000) % 1000).DoWorkAsync());
        Console.WriteLine($"All workers generated.");
        await Task.Delay(1000);
        LogThreadCount();
        LogCPUCount();
        Task.WaitAll(workers.ToArray());
        LogEnd(nameof(MultipleWorkerExampleAsync));
    }

    private void LogStart(string exampleName)
    {
        Console.WriteLine($"=== Start ({exampleName}) ===");
    }

    private void LogEnd(string exampleName)
    {
        Console.WriteLine($"=== End {exampleName} ===");
    }

    private void LogThreadCount()
    {
        Console.WriteLine($"Thread count :: '{Process.GetCurrentProcess().Threads.Count}'");
    }

    private void LogCPUCount()
    {
        Console.WriteLine($"CPU count :: '{Environment.ProcessorCount}'");
    }
}