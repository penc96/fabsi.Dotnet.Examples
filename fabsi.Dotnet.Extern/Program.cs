
using fabsi.Dotnet.Extern;
using System.Runtime.InteropServices;

var main = new Main();
Console.WriteLine($"Before");
var task = main.OpenDialogAsync();
Console.WriteLine($"After");
await task;

namespace fabsi.Dotnet.Extern
{
    class Main
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        public Task OpenDialogAsync(CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{nameof(OpenDialogAsync)} :: Start");
                int res = MessageBox(0, "Hello World", "Hello World 2", 0);
                Console.WriteLine($"{nameof(OpenDialogAsync)} :: End");
            }, ct);
        }
    }
}