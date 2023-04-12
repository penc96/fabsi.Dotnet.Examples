using fabsi.Dotnet.Web.OData.Sample.Entities;
using fabsi.Dotnet.Web.OData.Sample.Extensions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.OData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(y => y.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddDbContextPool<ODataSampleDbContext>(x =>
{
    var conn = new SqliteConnection("Data Source=:memory:;Cache=Shared;Pooling=false");
    conn.Open();
    x.UseSqlite(conn);
});

var app = builder.Build();

app.ConfigureMiddlewareOrder();

app.Run();