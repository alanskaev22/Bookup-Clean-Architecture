namespace BusinessManagement;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessManagementModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BusinessManagementOptions>(configuration.GetSection(BusinessManagementOptions.BusinessManagement));

        return services;
    }

    public static IApplicationBuilder UseBusinessManagementModule(this IApplicationBuilder app) =>
        // Add any middleware specific to the BusinessManagement module here
        app;
}
