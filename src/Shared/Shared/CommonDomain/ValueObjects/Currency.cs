namespace Shared.CommonDomain.ValueObjects;

public class Currency : ValueObject
{
    public string Code { get; private set; } = default!;

    public Result<string> Symbol => Code switch
    {
        "USD" => "$",
        "EUR" => "€",
        "GBP" => "£",
        _ => Error.ForBadRequest($"Symbol for currency code '{Code}' is not supported.")
    };

    private Currency()
    { }

    public static Result<Currency> Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return Error.ForBadRequest("Currency code cannot be empty.");
        }
        if (code.Length != 3)
        {
            return Error.ForBadRequest("Currency code must be exactly 3 characters long.");
        }

        return new Currency()
        {
            Code = code.Trim().ToUpperInvariant()
        };
    }

    public static Currency Empty => new()
    {
        Code = string.Empty
    };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
