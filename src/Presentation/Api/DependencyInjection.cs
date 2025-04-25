using Scalar.AspNetCore;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();

        services.Configure<ApiOptions>(configuration.GetSection(ApiOptions.Api));

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
