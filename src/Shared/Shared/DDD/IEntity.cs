namespace Shared.DDD;

public interface IEntity<TId> : IEntity
{
    TId Id { get; set; }
}

public interface IEntity
{
    DateTime? CreatedAt { get; set; }
    string? CreatedBy { get; set; }
    DateTime? LastModified { get; set; }
    string? LastModifiedby { get; set; }
}
