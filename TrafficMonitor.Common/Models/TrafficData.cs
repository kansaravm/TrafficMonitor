using TrafficMonitor.Common.DomainEvents;
using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.Models
{
    public class TrafficData : Entity,IAggregateRoot
    {
        public EagleBot EagleBot { get; set; } = default!;
        public Coordinate Location { get; set; } = default!;
        public string? RoadName { get; set; } 
        public Direction? Direction { get; set; } 
        public double? FlowRate { get; set; }
        public double? VehicleSpeed { get; set; }
        public DateTime? CreatedOn { get; set; }

        public static TrafficData Create(EagleBot eagleBot,Coordinate location,string roadName,Direction direction,double flowRate,double vehicleSpeed,IClock clock)
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
