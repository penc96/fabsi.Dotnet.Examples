using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabsi.Dotnet.Web.OData.Sample.Entities.Configurations;

public class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
{
    protected override string TableName => "Users";

    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.Property(x => x.PasswordHash);
        builder.HasMany(x => x.FavoriteDeals)
            .WithMany(x => x.UserFavorites);
    }
}