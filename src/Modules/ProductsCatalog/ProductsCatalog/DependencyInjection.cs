using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductsCatalog;

public static class DependencyInjection
{
    public static IServiceCollection AddProductsCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ProductsCatalogOptions>(configuration.GetSection(ProductsCatalogOptions.ProductsCatalog));

        return services;
    }

    public static IApplicationBuilder UseProductsCatalogModule(this IApplicationBuilder app) =>
    // Add any middleware specific to the BusinessManagement module here
    app;
}
