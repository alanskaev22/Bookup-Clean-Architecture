using Scalar.AspNetCore;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiOptions>(configuration.GetSection(ApiOptions.Api));
        services.AddControllers();
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSingleton(TimeProvider.System);

        return services;
    }

    public static IApplicationBuilder UseApi(this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
