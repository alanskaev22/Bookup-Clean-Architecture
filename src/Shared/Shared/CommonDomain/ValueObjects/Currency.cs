namespace Shared.CommonDomain.ValueObjects;

public class Currency : ValueObject
{
    public string Code { get; private set; } = default!;

    public string Symbol => Code switch
    {
        "USD" => "$",
        "EUR" => "€",
        "GBP" => "£",
        _ => throw new NotSupportedException($"Symbol for currency code '{Code}' is not supported.")
    };

    private Currency()
    { }

    public static Currency Create(string code)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentOutOfRangeException.ThrowIfNotEqual(code.Length, 3);

        return new()
        {
            Code = code.Trim().ToUpperInvariant()
        };
    }

    public static Currency Empty => Create(string.Empty);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
