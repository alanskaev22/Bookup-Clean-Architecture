namespace ProductsCatalog.Products.Models;

public sealed class Category : Entity<Guid>
{
    private readonly List<Product> _products = [];

    public string Name { get; private set; } = null!;

    /// <summary>
    /// Navigational Property. Only use to query, not update
    /// </summary>
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    private Category()
    { }

    public static Category Create(Guid tenantId, string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        return new()
        {
            TenantId = tenantId,
            Id = Guid.NewGuid(),
            Name = name,
        };
    }
}