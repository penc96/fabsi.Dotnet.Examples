
var main = new Main();

main.AllocateStaticMemory();

class Main
{
    public unsafe void AllocateStaticMemory()
    {
        fixed (char* example = "Hello World")
        {
            char* ptr = example;
            while (*ptr != '\0')
            {
                Console.WriteLine($"Next char :: {*ptr}");
                ptr++;
            }
        }
    }
}