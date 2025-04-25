namespace Shared.CommonDomain.ValueObjects;

public sealed class Url : ValueObject
{
    public string Value { get; private set; }

    private Url(string value) => Value = value;

    public static Url Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("URL cannot be empty.");
        }
        if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
        {
            throw new ArgumentException("Invalid URL format.");
        }

        return new(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
