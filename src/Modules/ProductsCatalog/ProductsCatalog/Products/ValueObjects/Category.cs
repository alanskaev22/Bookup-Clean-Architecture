namespace ProductsCatalog.Products.ValueObjects;

public sealed class Category : ValueObject
{
    public string Name { get; private set; } = default!;

    protected override IEnumerable<object> GetEqualityComponents() => throw new NotImplementedException();
}
