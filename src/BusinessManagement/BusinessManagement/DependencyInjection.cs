using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessManagement;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessManagementModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BusinessManagementOptions>(configuration.GetSection(BusinessManagementOptions.BusinessManagement));

        return services;
    }
}
