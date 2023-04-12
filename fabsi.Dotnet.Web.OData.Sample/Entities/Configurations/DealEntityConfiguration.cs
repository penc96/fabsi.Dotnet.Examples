using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabsi.Dotnet.Web.OData.Sample.Entities.Configurations;

public class DealEntityConfiguration : BaseEntityConfiguration<DealEntity>
{
    protected override string TableName => "Deals";

    public override void Configure(EntityTypeBuilder<DealEntity> builder)
    {
        base.Configure(builder);

        builder.Property<string>(x => x.ProductName);
        builder.Property<double?>(x => x.BasePrice);
        builder.Property<double>(x => x.DealPrice);
        builder.HasOne(x => x.Market);
        builder.HasMany(x => x.UserFavorites)
            .WithMany(x => x.FavoriteDeals);
    }
}