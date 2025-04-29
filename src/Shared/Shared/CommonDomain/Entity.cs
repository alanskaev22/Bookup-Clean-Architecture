namespace Shared.CommonDomain;

public class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; } = default!;
    public Guid TenantId { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedAt { get; set; }
    public string? LastModifiedby { get; set; }
}
