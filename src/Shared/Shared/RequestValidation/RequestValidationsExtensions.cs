using System.Reflection;

namespace Shared.RequestValidation;

public static class RequestValidationsExtensions
{
    public static IServiceCollection AddRequestsValidations(this IServiceCollection services, Assembly assembly) =>
        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);
}
