namespace fabsi.Dotnet.Web.OData.Sample.Dtos;

public class DealDto : BaseDto
{
    public string ProductName { get; set; } = string.Empty;
    public double? BasePrice { get; set; }
    public double DealPrice { get; set; }
    public MarketDto Market { get; set; } = null!;
    public int MarketId { get; set; }
}