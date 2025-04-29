namespace ProductsCatalog.Products.ValueObjects;

public sealed class ProductId : ValueObject
{
    public string Value { get; private set; } = default!;

    private ProductId()
    { }

    public static Result<ProductId> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Error.ForBadRequest("ProductId cannot be empty.");
        }

        return new ProductId()
        {
            Value = value
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
