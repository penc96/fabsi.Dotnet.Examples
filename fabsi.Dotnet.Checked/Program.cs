

int i = int.MaxValue;
Console.WriteLine($"=== Normal ===");
Console.WriteLine($"Value before: '{i}'");
i += 1;
Console.WriteLine($"Value after: '{i}'");

i = int.MaxValue;
Console.WriteLine($"=== Checked ===");
checked
{
    try
    {
        Console.WriteLine($"Value before: '{i}'");
        i += 1;
        Console.WriteLine($"Value after: '{i}'");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }
}

i = int.MaxValue;
Console.WriteLine($"=== Unchecked ===");
unchecked
{
    Console.WriteLine($"Value before: '{i}'");
    i += 1;
    Console.WriteLine($"Value after: '{i}'");
}
