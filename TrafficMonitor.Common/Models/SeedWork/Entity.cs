using TrafficMonitor.Common.DomainEvents.SeedWork;

namespace TrafficMonitor.Common.Models.SeedWork
{
    public class Entity : IEntity
    {
        public Guid? Id { get; set; }
        public byte[]? Timestamp { get; set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public void AddDomainEvent(IDomainEvent domainEvent)  => _domainEvents.Add(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
