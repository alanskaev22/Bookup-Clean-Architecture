using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DataAccess.Seed;

namespace Shared.DataAccess;

public static class Extensions
{
    public static IApplicationBuilder UseMigration<TContext>(this IApplicationBuilder app)
        where TContext : DbContext
    {
        MigrateDatabaseAsync<TContext>(app.ApplicationServices).GetAwaiter().GetResult();

        SeedDataAsync(app.ApplicationServices).GetAwaiter().GetResult();

        return app;
    }

    private static async Task MigrateDatabaseAsync<TContext>(IServiceProvider serviceProvider)
        where TContext : DbContext
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();

        await dbContext.Database.MigrateAsync();
    }

    private static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();
        foreach (var seeder in seeders)
        {
            await seeder.SeedAllAsync();
        }
    }

    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
        r.TargetEntry is not null &&
        r.TargetEntry.Metadata.IsOwned() &&
        (r.TargetEntry.State is EntityState.Added || r.TargetEntry.State is EntityState.Modified));
}
