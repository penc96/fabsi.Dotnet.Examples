using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabsi.Dotnet.Web.OData.Sample.Entities.Configurations;

public class MarketEntityConfiguration : BaseEntityConfiguration<MarketEntity>
{
    protected override string TableName => "Markets";

    public override void Configure(EntityTypeBuilder<MarketEntity> builder)
    {
        base.Configure(builder);

        builder.Property<string>(x => x.Name);
    }
}