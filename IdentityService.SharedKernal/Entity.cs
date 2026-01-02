namespace IdentityService.SharedKernal;

public abstract class Entity
{
    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public List<IDomainEvent> DomainEvents => _domainEvents;

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}