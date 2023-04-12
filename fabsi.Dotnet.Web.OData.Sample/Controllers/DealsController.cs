using fabsi.Dotnet.Web.OData.Sample.Entities;
using fabsi.Dotnet.Web.OData.Sample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace fabsi.Dotnet.Web.OData.Sample.Controllers;

[Route("api/[controller]")]
public class DealsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DealEntity>>> GetAllAsync([FromServices] IDealService dealService, CancellationToken ct = default)
    {
        return Ok(await dealService.GetAllAsync(ct));
    }
}
