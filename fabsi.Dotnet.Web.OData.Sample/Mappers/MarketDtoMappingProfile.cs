using AutoMapper;
using fabsi.Dotnet.Web.OData.Sample.Dtos;
using fabsi.Dotnet.Web.OData.Sample.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace fabsi.Dotnet.Web.OData.Sample.Mappers;

public class MarketDtoMappingProfile : Profile
{
    public MarketDtoMappingProfile()
    {
        CreateMap<MarketEntity, MarketDto>();
    }
}