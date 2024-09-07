using MediatR;
using TrafficMonitor.Common.DomainEvents.SeedWork;

namespace TrafficMonitor.Common.Models.SeedWork
{
    public interface IEntity
    {
        Guid? Id { get; set; }
        byte[]? Timestamp { get; set; }

        IEnumerable<IDomainEvent> DomainEvents { get; }
        public void ClearDomainEvents();

    }
}
