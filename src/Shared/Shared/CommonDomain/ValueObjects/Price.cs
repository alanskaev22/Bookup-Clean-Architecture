namespace Shared.CommonDomain.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Value { get; private set; }
    public Currency Currency { get; private set; }

    private Price(decimal value, Currency currency)
    {
        if (value < 0)
        {
            throw new ArgumentException("Price value cannot be negative.");
        }
        Value = value;
        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
    }

    public static Price Create(decimal value, Currency currency) => new(value, currency);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }
}
