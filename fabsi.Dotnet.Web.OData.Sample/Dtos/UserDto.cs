namespace fabsi.Dotnet.Web.OData.Sample.Dtos;

public class UserDto : BaseDto
{
    public string Email { get; set; } = string.Empty;
    public List<DealDto> FavoriteDeals { get; set; } = new();
}