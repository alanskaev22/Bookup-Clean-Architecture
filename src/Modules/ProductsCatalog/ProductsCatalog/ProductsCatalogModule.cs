using Microsoft.EntityFrameworkCore;
using ProductsCatalog.DataAccess;
using Shared.RequestValidation;

namespace ProductsCatalog;

public static class ProductsCatalogModule
{
    public static IServiceCollection AddProductsCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ProductsCatalogOptions>(configuration.GetSection(ProductsCatalogOptions.ProductsCatalog));
        services.AddRequestsValidations(typeof(ProductsCatalogModule).Assembly);
        services.AddDbContext<ProductsCatalogDbContext>(builder =>
        {
            builder.UseNpgsql(configuration.GetConnectionString("BookupDatabase"));
            builder.EnableDetailedErrors();
        });

        return services;
    }

    public static IApplicationBuilder UseProductsCatalogModule(this IApplicationBuilder app) =>
    // Add any middleware specific to the BusinessManagement module here
    app;
}
