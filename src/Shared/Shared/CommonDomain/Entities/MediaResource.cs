using Shared.CommonDomain.ValueObjects;

namespace Shared.CommonDomain.Entities;

public class MediaResource : Entity<Guid>
{
    public Url Url { get; private set; } = null!;
    public MediaResourceType Type { get; private set; }
    public int Order { get; private set; }
    public string? AltText { get; private set; }
    public string? MimeType { get; private set; }

    private MediaResource()
    { }

    private MediaResource(Url url, MediaResourceType type, int order, string? altText, string? mimeType)
    {
        Url = url;
        Type = type;
        Order = order;
        AltText = altText;
        MimeType = mimeType;
        Id = Guid.NewGuid();
    }

    public static MediaResource Create(Url url, MediaResourceType type, int order = 0, string? altText = null, string? mimeType = null)
    {
        var media = new MediaResource(url, type, order, altText, mimeType);

        return media;
    }
}
