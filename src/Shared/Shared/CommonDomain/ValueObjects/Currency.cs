namespace Shared.CommonDomain.ValueObjects;

public sealed class Currency : ValueObject
{
    public string Code { get; private set; }

    private Currency(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Currency code cannot be empty.");
        }

        code = code.Trim().ToUpperInvariant();

        if (code.Length != 3)
        {
            throw new ArgumentException("Currency code must be exactly 3 characters.");
        }

        Code = code;
    }

    public static Currency Create(string code) => new(code);

    public string Symbol => Code switch
    {
        "USD" => "$",
        "EUR" => "€",
        "GBP" => "£",
        _ => throw new NotSupportedException($"Symbol for currency code '{Code}' is not supported.")
    };

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
