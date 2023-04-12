
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Globalization;
using System.Text.RegularExpressions;
using Timer = System.Timers.Timer;

string oldContent = await File.ReadAllTextAsync("test.html");
string regex = @"(?<=<[^<>]*)[\r\n]+(?=[^<>]*>)";
regex = @"(<)";

string newContent = Regex.Replace(oldContent, regex, string.Empty);
var parse = new HtmlParser();
var doc = parse.ParseDocument(oldContent);
string p = doc.Prettify();

return 0;
var s = TimeSpan.ParseExact("39:05:00", @"h\:mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative);
Console.WriteLine(s.TotalMinutes);
return 0;
var timer = new Timer(1000);
timer.Elapsed += (sender, eventArgs) =>
{
    Console.WriteLine($"Trigger");
};
timer.AutoReset = true;
timer.Enabled = true;
timer.Start();

Console.WriteLine($"Press enter to exit.");
Console.ReadKey();