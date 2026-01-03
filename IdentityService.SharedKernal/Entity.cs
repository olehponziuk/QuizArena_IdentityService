namespace IdentityService.SharedKernal;

public abstract class Entity<TId>
{
    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public List<IDomainEvent> DomainEvents => _domainEvents;
    
    public TId Id { get; set; }

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}