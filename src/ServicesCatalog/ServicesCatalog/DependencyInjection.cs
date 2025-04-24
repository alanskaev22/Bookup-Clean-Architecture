using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServicesCatalog;

public static class DependencyInjection
{
    public static IServiceCollection AddServicesCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServicesCatalogOptions>(configuration.GetSection(ServicesCatalogOptions.ServicesCatalog));

        return services;
    }
}
