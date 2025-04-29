namespace Shared.RequestValidation;

internal sealed class RequestValidationApiFilter<TRequestToValidate> : IEndpointFilter where TRequestToValidate : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<TRequestToValidate>>();

        if (validator is null)
        {
            return await next.Invoke(context);
        }
        if (context.Arguments.FirstOrDefault(argument => argument?.GetType() == typeof(TRequestToValidate)) is not TRequestToValidate requestToValidate)
        {
            return await next.Invoke(context);
        }

        var validationResult = await validator.ValidateAsync(requestToValidate!);
        if (validationResult.IsValid)
        {
            return await next.Invoke(context);
        }

        var errors = validationResult.ToDictionary();

        return Results.ValidationProblem(errors,
            statusCode: (int)HttpStatusCode.BadRequest);
    }
}
