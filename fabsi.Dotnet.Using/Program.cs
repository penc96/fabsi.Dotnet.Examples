
try
{
    using var res = new CriticalResource();
    res.Explode();
}
catch (Exception e)
{
    Console.WriteLine($"An error occured :: {e.Message}");
}

class CriticalResource : IDisposable
{
    public CriticalResource()
    {
        Console.WriteLine($"{nameof(CriticalResource)} :: Constructor");
    }

    public void Explode()
    {
        throw new Exception("BOOOOM");
    }

    public void Dispose()
    {
        Console.WriteLine($"{nameof(CriticalResource)} :: Dispose");
    }
}