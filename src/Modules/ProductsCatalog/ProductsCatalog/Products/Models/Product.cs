using ProductsCatalog.Products.Events.Domain;

namespace ProductsCatalog.Products.Models;

public class Product : Aggregate<ProductId>
{
    private readonly List<MediaResource> _media = [];
    private readonly List<Category> _categories = [];

    public string Name { get; private set; } = null!;
    public string Brand { get; set; } = null!;
    public string Description { get; private set; } = null!;
    public Money SellingPrice { get; private set; } = null!;
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
    public IReadOnlyCollection<MediaResource> Media => _media.AsReadOnly();

    private Product()
    { }

    public static Product Create(Guid tenantId, ProductId productId, string name, string brand, string description, Money sellingPrice, List<Category> categories, List<MediaResource> mediaResource)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(brand);
        ArgumentException.ThrowIfNullOrEmpty(description);
        ArgumentOutOfRangeException.ThrowIfEqual(categories.Count, 0);

        var product = new Product()
        {
            TenantId = tenantId,
            Id = productId,
            Name = name,
            Brand = brand,
            Description = description,
            SellingPrice = sellingPrice,
        };

        product._categories.AddRange(categories);
        product._media.AddRange(mediaResource);

        product.AddDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public void Update(string name, string brand, string description, Money sellingPrice, List<Category> categories, List<MediaResource> mediaResource)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(brand);
        ArgumentException.ThrowIfNullOrEmpty(description);
        ArgumentOutOfRangeException.ThrowIfEqual(categories.Count, 0);

        Name = name;
        Brand = brand;
        Description = description;
        SellingPrice = sellingPrice;

        _categories.Clear();
        _categories.AddRange(categories);

        _media.Clear();
        _media.AddRange(mediaResource);

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
