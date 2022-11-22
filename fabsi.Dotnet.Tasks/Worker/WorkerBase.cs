using System.Diagnostics;

namespace fabsi.Dotnet.Tasks.Worker;

public class WorkerBase
{
    protected void LogStart(string id = "")
    {
        string className = GetType().Name;
        Console.WriteLine($"{className}{(!string.IsNullOrWhiteSpace(id) ? $"-{id}" : string.Empty)} :: DoAsync :: Start");
    }

    protected void LogEnd()
    {
        string className = GetType().Name;
        Console.WriteLine($"{className} :: DoAsync :: End");
    }

    protected void LogProcessInfo()
    {
        Console.WriteLine($"Process: '{Environment.ProcessId}' | Thread: '{Environment.CurrentManagedThreadId}')");
    }
}