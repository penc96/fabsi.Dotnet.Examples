using fabsi.Dotnet.Web.OData.Sample.Entities;
using Microsoft.EntityFrameworkCore;

namespace fabsi.Dotnet.Web.OData.Sample.Services;

public interface IDealService
{
    Task<IEnumerable<DealEntity>> GetAllAsync(CancellationToken ct = default);
    Task<IEnumerable<DealEntity>> GetByFilterAsync(HttpRequest request, CancellationToken ct = default);
}

public class DealService : IDealService
{
    public ODataSampleDbContext ODataSampleDbContext { get; }
    public DealService(ODataSampleDbContext oDataSampleDbContext)
    {
        ODataSampleDbContext = oDataSampleDbContext;
    }

    public async Task<IEnumerable<DealEntity>> GetAllAsync(CancellationToken ct = default)
    {
        return await ODataSampleDbContext.Deals.ToListAsync(ct);
    }

    public async Task<IEnumerable<DealEntity>> GetByFilterAsync(HttpRequest request, CancellationToken ct = default)
    {
        return await ODataSampleDbContext.Deals.ToListAsync(ct);
    }
}