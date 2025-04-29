using Shared.RequestValidation;

namespace BusinessManagement;

public static class BusinessManagementModule
{
    public static IServiceCollection AddBusinessManagementModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BusinessManagementOptions>(configuration.GetSection(BusinessManagementOptions.BusinessManagement));
        services.AddRequestsValidations(typeof(BusinessManagementModule).Assembly);

        return services;
    }

    public static IApplicationBuilder UseBusinessManagementModule(this IApplicationBuilder app) =>
        // Add any middleware specific to the BusinessManagement module here
        app;
}
