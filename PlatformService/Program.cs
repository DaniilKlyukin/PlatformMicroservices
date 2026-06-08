using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Data.Common;
using PlatformService.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("--> Использование InMemory базы данных (Development)");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
}
else
{
    Console.WriteLine("--> Использование SQL Server (Production)");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));
}

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.MapOpenApi();

PrepDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();