namespace fabsi.Dotnet.Web.OData.Sample.Entities;

public class UserEntity : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public List<DealEntity> FavoriteDeals { get; set; } = new();
}