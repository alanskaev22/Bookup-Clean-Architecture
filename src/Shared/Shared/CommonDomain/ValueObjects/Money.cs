namespace Shared.CommonDomain.ValueObjects;

public sealed class Money : ValueObject
{
    public decimal Amount { get; private set; } = default!;

    public Currency Currency { get; private set; } = default!;

    public bool IsZero => Amount == 0 && Currency == Currency.Empty;

    public static Money Zero => Create(0, Currency.Empty);

    private Money()
    { }

    public static Money Create(decimal amount, Currency currency)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(amount, 0);

        return new()
        {
            Amount = ApplyBankersRounding(amount),
            Currency = currency
        };
    }

    public Money Add(Money other)
    {
        if (other.IsZero)
        {
            return this;
        }
        if (Currency == other.Currency)
        {
            return Create(Amount + other.Amount, Currency);
        }

        throw new InvalidOperationException($"Cannot add money with different currencies: {Currency} and {other.Currency}");
    }

    // TODO: Add Subtract/etc https://youtu.be/2izb2y819KU?si=i0UKChh4f4Yk88ID&t=91

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    private static decimal ApplyBankersRounding(decimal amount) => Math.Round(amount, 2, MidpointRounding.ToEven);
}
