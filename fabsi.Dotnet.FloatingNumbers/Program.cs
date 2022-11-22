
float n1 = 1.1f;
double d1 = 1.1d;

Console.WriteLine($"Float value :: '{n1}'");
Console.WriteLine($"Double value :: '{d1}'");

for (float i = 10; i >= 0; i -= 0.1f)
{
    Console.WriteLine($"i :: '{i}'");
}

for (double i = 10; i >= 0; i -= 0.1d)
{
    Console.WriteLine($"i :: '{i}'");
}