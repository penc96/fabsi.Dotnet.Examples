using AutoMapper;
using AutoMapper.QueryableExtensions;
using fabsi.Dotnet.Web.OData.Sample.Dtos;
using fabsi.Dotnet.Web.OData.Sample.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Newtonsoft.Json;

namespace fabsi.Dotnet.Web.OData.Sample.Controllers;

[Route($"odata/deals")]
public class DealsODataController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ODataResultDto<DealDto, DealEntity>>> GetByODataAsync(
        [FromServices] IMapper mapper,
        [FromServices] ODataSampleDbContext oDataSampleDbContext,
        CancellationToken ct = default)
    {
        var dealsSet = oDataSampleDbContext.Set<DealEntity>()
            .Include(x => x.Market);
        return Ok(new ODataResultDto<DealDto, DealEntity>(mapper, Request, dealsSet));
    }
}

public class ODataResultDto<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    public ODataResultDto(IMapper mapper, HttpRequest request, IQueryable<TEntity> dataSet)
    {
        var edmModelBuilder = new ODataConventionModelBuilder();
        edmModelBuilder.EntitySet<TEntity>(nameof(TEntity));

        var oDataQueryContext = new ODataQueryContext(edmModelBuilder.GetEdmModel(), typeof(TEntity), request.ODataFeature().Path);

        var oDataOptions = new ODataQueryOptions(oDataQueryContext, request);

        var data = new List<TEntity>((IQueryable<TEntity>)oDataOptions.ApplyTo(dataSet));
        Data = mapper.Map<List<TDto>>(data);
        if (oDataOptions.Count.Value)
        {
            ODataCount = dataSet.Count();
        }
    }

    [JsonProperty(PropertyName = "@odata.context")]
    public string ODataContext { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "@odata.count")]
    public int ODataCount { get; set; }

    [JsonProperty(PropertyName = "value")]
    public IList<TDto>? Data { get; set; }
}