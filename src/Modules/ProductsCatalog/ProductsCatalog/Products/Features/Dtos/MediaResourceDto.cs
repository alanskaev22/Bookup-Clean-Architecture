namespace ProductsCatalog.Products.Features.Dtos;

public class MediaResourceDto
{
    public Uri Url { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int Order { get; set; }
    public string? AltText { get; set; }
    public string? MimeType { get; set; }
}
