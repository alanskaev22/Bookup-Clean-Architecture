using Microsoft.AspNetCore.Builder;

namespace Shared.RequestValidation;

public static class EndpointBuilderExtensions
{
    public static RouteHandlerBuilder ValidateRequest<TRequest>(this RouteHandlerBuilder builder) where TRequest : class =>
        builder.AddEndpointFilter<RequestValidationApiFilter<TRequest>>();
}
