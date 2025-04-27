using Microsoft.EntityFrameworkCore;
using ProductsCatalog.DataAccess;
using ProductsCatalog.DataAccess.Seed;

namespace ProductsCatalog;

public static class ProductsCatalogModule
{
    public static IServiceCollection AddProductsCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ProductsCatalogOptions>(configuration.GetSection(ProductsCatalogOptions.ProductsCatalog));
        services.AddRequestsValidations(typeof(ProductsCatalogModule).Assembly);

        // Data Access
        services.AddDbContext<ProductsCatalogDbContext>(builder =>
        {
            builder.UseNpgsql(configuration.GetConnectionString("BookupDatabase"));
            builder.EnableDetailedErrors();
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
