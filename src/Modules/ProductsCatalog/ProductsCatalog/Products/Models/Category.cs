namespace ProductsCatalog.Products.Models;

public sealed class Category : Entity<Guid>
{
    private readonly List<Product> _products = [];

    public string CategoryName { get; private set; }
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    private Category(Guid tenantId, string categoryName) : base(tenantId) => CategoryName = categoryName;

    public static Category Create(Guid tenantId, string categoryName)
    {
        ArgumentException.ThrowIfNullOrEmpty(categoryName);

        return new(tenantId, categoryName);
    }
}
