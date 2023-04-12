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

    public Task DoWorkAsync()
    {
        return Task.Run(() =>
        {
            int x = 0;
            while (x < 1000000)
            {
                // TODO: do long stuff
                Console.WriteLine(x);
                x++;
            }
        });
        // for (int i = 0; i < WaitTime; i++)
        // {
        //     if (i % 100 == 0)
        //         LogProcessInfo();
        //     await Task.Delay(1);
        // }
    }

    private async Task Example1()
    {
        int x = 0;
        while (x < 2)
        {
            // TODO: do long stuff
            Console.WriteLine(x);
            x++;
            await Task.Delay(1000);
        }
    }

    private async Task Example2()
    {
        int x = 0;
        while (x < 2)
        {
            // TODO: do long stuff
            Console.WriteLine(x);
            x++;
            await Task.Delay(1000);
        }
    }
}