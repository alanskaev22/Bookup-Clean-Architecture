namespace ProductsCatalog;

public class ProductsCatalogOptions
{
    public const string ProductsCatalog = "ProductsCatalog";

    public ConnectionStrings ConnectionStrings { get; set; } = null!;
}

public class ConnectionStrings
{
    public string BookupDatabase { get; init; } = null!;
}
