namespace Shared.CommonDomain.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Value { get; private set; }
    public Currency Currency { get; private set; }

    private Price(decimal value, Currency currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Price Create(decimal value, Currency currency)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
        if (value < 0)
        {
            throw new ArgumentException("Price value cannot be negative.");
        }
        return new(value, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }
}
