namespace ProductsCatalog.Products.Features.CreateProduct;

public record CreateProductCommand(string ProductId,
                                   string Name,
                                   string Brand,
                                   string Description,
                                   decimal Price,
                                   List<string> Categories,
                                   List<MediaResource> Media) : ICommand<Result>;
