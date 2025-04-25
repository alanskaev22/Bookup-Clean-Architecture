namespace ProductsCatalog.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    public string Value { get; private set; }

    private ProductId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("ProductId cannot be empty.");
        }
        Value = value;
    }

    public static ProductId Create(string value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
