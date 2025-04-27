using Microsoft.EntityFrameworkCore;
using ProductsCatalog.DataAccess;
using ProductsCatalog.DataAccess.Seed;
using Shared.DataAccess.Interceptors;

namespace ProductsCatalog;

public static class ProductsCatalogModule
{
    public static IServiceCollection AddProductsCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ProductsCatalogOptions>(configuration.GetSection(ProductsCatalogOptions.ProductsCatalog));
        services.AddRequestsValidations(typeof(ProductsCatalogModule).Assembly);

        // Data Access
        services.AddDbContext<ProductsCatalogDbContext>((sp, options) =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor(sp.GetRequiredService<TimeProvider>()));
            options.UseNpgsql(configuration.GetConnectionString(ProductsCatalogOptions.BookupDatabaseKeyName));
            options.EnableDetailedErrors();
        });
        services.AddScoped<IDataSeeder, ProductsCatalogSeeder>();

        return services;
    }

    public static IApplicationBuilder UseProductsCatalogModule(this IApplicationBuilder app)
    {
        app.UseMigration<ProductsCatalogDbContext>();

        return app;
    }
}
