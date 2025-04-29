namespace Shared.CommonDomain;

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    DateTimeOffset OccurredOn => DateTimeOffset.Now;
    string EventType => GetType().AssemblyQualifiedName!;
}
