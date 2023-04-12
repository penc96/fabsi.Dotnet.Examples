namespace fabsi.Dotnet.Web.OData.Sample.Entities;

public class DealEntity : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public double? BasePrice { get; set; }
    public double DealPrice { get; set; }

    public MarketEntity Market { get; set; } = null!;
    public int MarketId { get; set; }

    public List<UserEntity> UserFavorites { get; set; } = new();
}