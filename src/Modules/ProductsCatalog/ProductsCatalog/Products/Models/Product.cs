using ProductsCatalog.Products.Events.Domain;

namespace ProductsCatalog.Products.Models;

public class Product : Aggregate<ProductId>
{
    private readonly List<MediaResource> _media = [];

    public string Name { get; private set; }
    public List<Category> Categories { get; private set; }
    public string Description { get; private set; }
    public Price Price { get; private set; }
    public IReadOnlyCollection<MediaResource> Media => _media.AsReadOnly();

    private Product(ProductId productId, string name, List<Category> categories, string description, Price price)
    {
        Id = productId;
        Name = name;
        Categories = categories;
        Description = description;
        Price = price;
    }

    public static Product Create(ProductId productId, string name, List<Category> categories, string description, Price price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        var product = new Product(productId, name, categories, description, price);

        product.AddDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public void Update(string name, List<Category> categories, string description, Price price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        Name = name;
        Categories = categories;
        Description = description;
        Price = price;

        // If price has changed, add a domain event
        if (Price != price)
        {
            Price = price;
            AddDomainEvent(new ProductPriceChangedDomainEvent(this));
        }
    }

    public void AddMedia(Url url, MediaResourceType type, int order = 0, string? altText = null, string? mimeType = null)
    {
        var media = MediaResource.Create(url, type, order, altText, mimeType);

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
