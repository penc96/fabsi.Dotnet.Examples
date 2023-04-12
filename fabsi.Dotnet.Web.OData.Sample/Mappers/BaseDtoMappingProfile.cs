using AutoMapper;
using fabsi.Dotnet.Web.OData.Sample.Dtos;
using fabsi.Dotnet.Web.OData.Sample.Entities;

namespace fabsi.Dotnet.Web.OData.Sample.Mappers;

public class BaseDtoMappingProfile : Profile
{
    public BaseDtoMappingProfile()
    {
        CreateMap<BaseDto, BaseEntity>()
            .IncludeAllDerived();
    }
}