using ProductsCatalog.Products.Events.Domain;

namespace ProductsCatalog.Products.Domain;

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

    public static Result<Product> Create(Guid tenantId, ProductId productId, string name, string brand, string description, Money sellingPrice, List<Category> categories, List<MediaResource> mediaResource)
    {
        var result = ValidateProduct(name, brand, description, categories);
        if (result.IsFailure)
        {
            return result.Error;
        }

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

    public Result Update(string name, string brand, string description, Money sellingPrice, List<Category> categories, List<MediaResource> mediaResource)
    {
        var result = ValidateProduct(name, brand, description, categories);
        if (result.IsFailure)
        {
            return result.Error;
        }

        Name = name;
        Brand = brand;
        Description = description;
        SellingPrice = sellingPrice;

        _categories.Clear();
        _categories.AddRange(categories);

        _media.Clear();
        _media.AddRange(mediaResource);

        if (SellingPrice != sellingPrice)
        {
            SellingPrice = sellingPrice;
            AddDomainEvent(new ProductPriceChangedDomainEvent(this));
        }

        return Result.Success();
    }

    public Result AddMedia(Guid tenantId, Url url, MediaResourceType type, int order = 0, string? altText = null, string? mimeType = null)
    {
        var media = MediaResource.Create(tenantId, url, type, order, altText, mimeType);
        if (media.IsFailure)
        {
            return media.Error;
        }

        _media.Add(media.Value);

        return Result.Success();
    }

    public Result RemoveMedia(Guid mediaId)
    {
        var media = _media.FirstOrDefault(m => m.Id == mediaId);
        if (media != null)
        {
            _media.Remove(media);
        }

        return Result.Success();
    }

    private static Result ValidateProduct(string name, string brand, string description, List<Category> categories)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.ForBadRequest("Product name cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(brand))
        {
            return Error.ForBadRequest("Brand cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            return Error.ForBadRequest("Description cannot be empty.");
        }
        if (categories.Count == 0)
        {
            return Error.ForBadRequest("Product must be associated with at least 1 category.");
        }

        return Result.Success();
    }
}
