namespace Shared.CommonDomain.ValueObjects;

public sealed class Url : ValueObject
{
    public string Value { get; private set; }

    private Url(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("URL cannot be empty.");
        }
        value = value.Trim();
        if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
        {
            throw new ArgumentException("Invalid URL format.");
        }
        Value = value;
    }

    public static Url Create(string value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
