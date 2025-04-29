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

    public static Result<Category> Create(Guid tenantId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.ForBadRequest("Category name cannot be empty.");
        }

        return new Category()
        {
            TenantId = tenantId,
            Id = Guid.NewGuid(),
            Name = name,
        };
    }
}
