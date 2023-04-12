using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace fabsi.Dotnet.Web.OData.Sample.Entities;

public class ODataSampleDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DealEntity> Deals { get; set; }
    public DbSet<MarketEntity> Markets { get; set; }

    public ODataSampleDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly()!);
    }
}