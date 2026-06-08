using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data.Common;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        SeedData(context, isProd);
    }

    private static void SeedData(AppDbContext context, bool isProd)
    {
        if (context.Database.IsRelational())
        {
            Console.WriteLine("--> Применение миграций базы данных...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Ошибка при применении миграций: {ex.Message}");
            }
        }

        if (!isProd && !context.Platforms.Any())
        {
            Console.WriteLine("--> Заполнение базы данных тестовыми данными...");

            context.Platforms.AddRange(
                new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> В базе данных уже есть данные.");
        }
    }
}
