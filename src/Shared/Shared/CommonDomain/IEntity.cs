namespace Shared.CommonDomain;

public interface IEntity<TId> : IEntity
{
    TId Id { get; set; }
}

public interface IEntity
{
    DateTimeOffset? CreatedAt { get; set; }
    string? CreatedBy { get; set; }
    DateTimeOffset? LastModifiedAt { get; set; }
    string? LastModifiedby { get; set; }
}
