
using System.Threading.Channels;

var main1 = new Main("Main1");
var main2 = new Main("Main2");

Console.WriteLine($"Name before :: {main1.Name}");
main2.TryOverwriteInstance(out main1);
Console.WriteLine($"Name after :: {main1.Name}");

class Main
{
    public string Name { get; set; }
    public Main(string name)
    {
        Name = name;
    }
    public void TryOverwriteInstance(Main main)
    {
        main = this;
    }
    public void TryOverwriteInstance(out Main main)
    {
        main = this;
    }
}