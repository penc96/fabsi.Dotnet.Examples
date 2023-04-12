using AutoMapper;
using fabsi.Dotnet.Web.OData.Sample.Dtos;
using fabsi.Dotnet.Web.OData.Sample.Entities;

namespace fabsi.Dotnet.Web.OData.Sample.Mappers;

public class UserDtoMappingProfile : Profile
{
    public UserDtoMappingProfile()
    {
        CreateMap<UserEntity, UserDto>();
    }
}