using BenchmarkDotNet.Attributes;
using Flurl;
using Flurl.Http;

namespace fabsi.Dotnet.Web.OData.Benchmark;

public class ODataBenchmark
{
    private const string BASE_URL = "http://localhost:5000";

    [Benchmark]
    public async Task GetData_WithEdmModelGeneratedEveryTime_ByODataAsync()
    {
        var response = await $"{BASE_URL}/api/deals/odata/edmeverytime"
            .GetAsync();
        if (response.StatusCode > 200)
            throw new Exception("Error");
    }

    [Benchmark]
    public async Task GetData_WithEdmModelGeneratedOnce_ByODataAsync()
    {
        var response = await $"{BASE_URL}/api/odata/deals/once"
            .GetAsync();
        if (response.StatusCode > 200)
            throw new Exception("Error");
    }
}
