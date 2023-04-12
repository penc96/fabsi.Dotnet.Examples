using AutoMapper;
using fabsi.Dotnet.Web.OData.Sample.Dtos;
using fabsi.Dotnet.Web.OData.Sample.Entities;

namespace fabsi.Dotnet.Web.OData.Sample.Mappers;

public class DealDtoMappingProfile : Profile
{
    public DealDtoMappingProfile()
    {
        CreateMap<DealEntity, DealDto>();
    }
}