using ProductsCatalog.Products.Events.Domain;

namespace ProductsCatalog.Products.Models;

public class Product : Aggregate<ProductId>
{
    private readonly List<MediaResource> _media = [];
    private readonly List<Category> _categories = [];

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Price SellingPrice { get; private set; }
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
    public IReadOnlyCollection<MediaResource> Media => _media.AsReadOnly();

    private Product(Guid tenantId, ProductId productId, string name, List<Category> categories, string description, Price sellingPrice) : base(tenantId)
    {
        Id = productId;
        Name = name;
        Description = description;
        SellingPrice = sellingPrice;
        _categories.AddRange(categories);
    }

    public static Product Create(Guid tenantId, ProductId productId, string name, List<Category> categories, string description, Price sellingPrice)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);
        ArgumentOutOfRangeException.ThrowIfEqual(categories.Count, 0);

        var product = new Product(tenantId, productId, name, categories, description, sellingPrice);

        product.AddDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public void Update(string name, List<Category> categories, string description, Price sellingPrice)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);
        ArgumentOutOfRangeException.ThrowIfEqual(categories.Count, 0);

        Name = name;
        Description = description;
        SellingPrice = sellingPrice;

        _categories.Clear();
        _categories.AddRange(categories);

        // If price has changed, add a domain event
        if (SellingPrice != sellingPrice)
        {
            SellingPrice = sellingPrice;
            AddDomainEvent(new ProductPriceChangedDomainEvent(this));
        }
    }

    public void AddMedia(Guid tenantId, Url url, MediaResourceType type, int order = 0, string? altText = null, string? mimeType = null)
    {
        var media = MediaResource.Create(tenantId, url, type, order, altText, mimeType);

        _media.Add(media);
    }

    public void RemoveMedia(Guid mediaId)
    {
        var media = _media.FirstOrDefault(m => m.Id == mediaId);
        if (media != null)
        {
            _media.Remove(media);
        }
    }
}
