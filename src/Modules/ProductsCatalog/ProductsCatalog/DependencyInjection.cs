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
}