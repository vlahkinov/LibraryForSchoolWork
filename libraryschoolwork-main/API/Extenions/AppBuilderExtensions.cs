using Data;
using Microsoft.EntityFrameworkCore;

namespace Extenions
{
    public static class AppBuilderExtensions
    {
        public static async Task UpdateDatabaseAsync(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<LibraryContext>();
            await context.Database.MigrateAsync();
            await SeedDataAsync(context);
        }

        private static async Task SeedDataAsync(LibraryContext context)
        {
            await Seeder.Seed(context);
        }

    }
}

