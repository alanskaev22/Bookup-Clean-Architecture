using ProductsCatalog.Products.Domain;

namespace ProductsCatalog.Products.Events.Domain;

public sealed record ProductPriceChangedDomainEvent(Product Product) : IDomainEvent;
