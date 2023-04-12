namespace fabsi.Dotnet.Web.OData.Sample.Dtos;

public class BaseDto
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}