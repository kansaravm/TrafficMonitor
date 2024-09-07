using TrafficMonitor.Common.DomainEvents.SeedWork;
using TrafficMonitor.Common.Models;
using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.DomainEvents
{
    public class TrafficDataCreated :IDomainEvent
    {       

        public TrafficDataCreated(TrafficData trafficData,IClock clock)
        {
            
            OccurredOn = clock.GetUtcNow();
            TrafficData = trafficData;
        }

       
        public DateTime OccurredOn { get; }
        public TrafficData TrafficData { get; }
    }
}
