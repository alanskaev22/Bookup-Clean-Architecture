namespace ProductsCatalog.Products.Events.Domain;

public sealed record ProductCreatedDomainEvent(Product Product) : IDomainEvent;
