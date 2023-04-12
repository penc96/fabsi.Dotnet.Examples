using fabsi.Dotnet.Web.OData.Sample.Entities;
using Microsoft.EntityFrameworkCore;

namespace fabsi.Dotnet.Web.OData.Sample.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureMiddlewareOrder(this WebApplication webApp)
    {
        webApp.UseCors();

        webApp.UseDatabaseMigration();

        if (webApp.Environment.IsDevelopment())
        {
            webApp.UseSwagger();
            webApp.UseSwaggerUI();
        }
        else if (webApp.Environment.IsProduction())
        {
            webApp.UseHttpsRedirection();
        }

        webApp.MapControllers();

        return webApp;
    }

    private static void UseDatabaseMigration(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ODataSampleDbContext>();

        dbContext.Database.EnsureCreated();

        webApp.UseTestData(dbContext);
    }

    private static void UseTestData(this WebApplication webApp, ODataSampleDbContext dbContext)
    {
        // markets

        string[] marketNames =
        {
            "Rewe", "Lidl", "Netto", "Aldi", "Edeka",
        };
        var markets = marketNames.Select(x => new MarketEntity
        {
            Name = x,
        });
        dbContext.Markets.AddRange(markets);
        dbContext.SaveChanges();


        // deals

        string[] productNames =
        {
            "Milch", "Eier", "Mehl", "Zucker", "Äpfel", "Birnen", "Zitronen", "Puderzucker", "Quark",
            "Fleisch", "Toast", "Brot", "Salami", "Pizza"
        };
        var market = dbContext.Markets.First();
        var random = new Random(123);
        var deals = productNames.Select(x => new DealEntity
        {
            BasePrice = null,
            DealPrice = Math.Round(random.NextDouble() * 5, 2),
            ProductName = x,
            MarketId = market.Id,
        });
        dbContext.Deals.AddRange(deals);
        dbContext.SaveChanges();

        // users

        string[] emails =
        {
            "admin1@email.com", "admin2@email.com", "test1@email.com",
        };

        var users = emails.Select(x => new UserEntity
        {
            Email = x,
            PasswordHash = string.Empty,
            FavoriteDeals = dbContext.Deals.Where(y => y.DealPrice < 3.0d).ToList()
        });

        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();
    }
}