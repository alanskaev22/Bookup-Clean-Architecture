using Shared.RequestValidation;

namespace ServicesCatalog;

public static class ServicesCatalogModule
{
    public static IServiceCollection AddServicesCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServicesCatalogOptions>(configuration.GetSection(ServicesCatalogOptions.ServicesCatalog));
        services.AddRequestsValidations(typeof(ServicesCatalogModule).Assembly);

        return services;
    }

    public static IApplicationBuilder UseServicesCatalogModule(this IApplicationBuilder app) =>
    // Add any middleware specific to the BusinessManagement module here
    app;
}
