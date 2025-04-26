namespace ProductsCatalog.Products.Models;

public sealed class Category : Entity<Guid>
{
    private readonly List<Product> _products = [];

    public string Name { get; private set; }
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    private Category(Guid tenantId, string name) : base(tenantId) => Name = name;

    public static Category Create(Guid tenantId, string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        return new(tenantId, name);
    }
}
