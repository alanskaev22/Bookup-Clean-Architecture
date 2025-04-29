namespace Shared.CommonDomain.ValueObjects;

public sealed class Url : ValueObject
{
    public string Value { get; private set; }

    private Url(string value) => Value = value;

    public static Result<Url> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Error.ForBadRequest("URL cannot be empty.");
        }
        if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
        {
            return Error.ForBadRequest("Invalid URL format.");
        }

        return new Url(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
