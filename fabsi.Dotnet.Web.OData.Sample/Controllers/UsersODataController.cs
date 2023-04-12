using AutoMapper;
using fabsi.Dotnet.Web.OData.Sample.Dtos;
using fabsi.Dotnet.Web.OData.Sample.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fabsi.Dotnet.Web.OData.Sample.Controllers;

[Route("odata/users")]
public class UsersODataController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ODataResultDto<UserDto, UserEntity>>> GetByODataAsync(
        [FromServices] IMapper mapper,
        [FromServices] ODataSampleDbContext oDataSampleDbContext)
    {
        var usersSet = oDataSampleDbContext.Set<UserEntity>()
            .Include(x => x.FavoriteDeals);
        return Ok(new ODataResultDto<UserDto, UserEntity>(mapper, Request, usersSet));
    }
}