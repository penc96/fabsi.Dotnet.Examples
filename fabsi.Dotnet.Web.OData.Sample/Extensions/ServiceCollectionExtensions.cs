using fabsi.Dotnet.Web.OData.Sample.Services;

namespace fabsi.Dotnet.Web.OData.Sample.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddTransient<IDealService, DealService>();
    }
}