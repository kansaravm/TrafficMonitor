using MediatR;

namespace TrafficMonitor.Common.DomainEvents.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get;}
    }
}
