namespace Shared.CommonDomain.ValueObjects;

public sealed class Currency : ValueObject
{
    public string Code { get; private set; }

    private Currency(string code) => Code = code;

    public static Currency Create(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentOutOfRangeException.ThrowIfNotEqual(code.Length, 3);
        code = code.Trim().ToUpperInvariant();

        return new(code);
    }

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
