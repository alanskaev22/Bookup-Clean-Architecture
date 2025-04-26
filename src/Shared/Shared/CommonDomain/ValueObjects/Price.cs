namespace Shared.CommonDomain.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public string Symbol => Currency switch
    {
        "USD" => "$",
        "EUR" => "€",
        "GBP" => "£",
        _ => throw new NotSupportedException($"Symbol for currency code '{Currency}' is not supported.")
    };

    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(decimal amount, string currency)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(amount, 0);
        ArgumentException.ThrowIfNullOrWhiteSpace(currency);
        ArgumentOutOfRangeException.ThrowIfNotEqual(currency.Length, 3);

        currency = currency.Trim().ToUpperInvariant();

        return new(amount, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
