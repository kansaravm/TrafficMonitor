using TrafficMonitor.Common.DomainEvents;
using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.Models
{
    public class TrafficData : Entity,IAggregateRoot
    {
        public EagleBot EagleBot { get; set; } = default!;
        public Point Location { get; set; } = default!;
        public string RoadName { get; set; } = default!;
        public Direction Direction { get; set; } = default!;
        public decimal FlowRate { get; set; }
        public decimal VehicleSpeed { get; set; }
        public DateTime? CreatedOn { get; set; }

        public static TrafficData Create(EagleBot eagleBot,Point location,string roadName,Direction direction,decimal flowRate,decimal vehicleSpeed,IClock clock)
        {
            var trafficData = new TrafficData
            {
                EagleBot = eagleBot,
                Location = location,
                RoadName = roadName,
                Direction = direction,                    
                FlowRate = flowRate,
                VehicleSpeed=vehicleSpeed,
                CreatedOn =clock.GetUtcNow()
            };
            trafficData.AddDomainEvent(new TrafficDataCreated(trafficData, clock));
            return trafficData;
        }
    }
}
