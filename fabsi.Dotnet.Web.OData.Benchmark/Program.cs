
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using fabsi.Dotnet.Web.OData.Benchmark;

// var oDataBenchmarkRunner = new ODataBenchmark();
// await oDataBenchmarkRunner.GetDataByODataAsync();

var results = BenchmarkRunner.Run<ODataBenchmark>();

Console.Write($"Press any key to exit..");
Console.ReadKey();
