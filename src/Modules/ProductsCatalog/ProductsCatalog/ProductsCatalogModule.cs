using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProductsCatalog.DataAccess;
using ProductsCatalog.DataAccess.Seed;
using Shared.DataAccess.Interceptors;

namespace ProductsCatalog;

public static class ProductsCatalogModule
{
    public static IServiceCollection AddProductsCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        // Application
        services.AddApplication(configuration);

        // Data Access
        services.AddDataAccess(configuration);

        return services;
    }

    public static IApplicationBuilder UseProductsCatalogModule(this IApplicationBuilder app)
    {
        app.UseMigration<ProductsCatalogDbContext>();

        return app;
    }

    private static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ProductsCatalogOptions>(configuration.GetSection(ProductsCatalogOptions.ProductsCatalog));
        services.AddRequestsValidations(typeof(ProductsCatalogModule).Assembly);
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    private static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddDbContext<ProductsCatalogDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(configuration.GetConnectionString(ProductsCatalogOptions.BookupDatabaseKeyName));
            options.EnableDetailedErrors();
        });
        services.AddScoped<IDataSeeder, ProductsCatalogSeeder>();
    }
}
