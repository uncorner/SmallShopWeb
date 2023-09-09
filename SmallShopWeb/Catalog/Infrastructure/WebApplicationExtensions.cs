using Microsoft.EntityFrameworkCore;

namespace SmallShopWeb.Catalog.Infrastructure
{
    internal static class WebApplicationExtensions
    {
        public static void ApplyDbMigrationsIfNeeded(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
