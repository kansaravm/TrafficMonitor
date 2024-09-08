using TrafficMonitor.Common.DomainEvents;
using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.Models
{
    public class TrafficData : Entity, IAggregateRoot
    {
        public  Guid EagleBotId { get; set; }  = default!;
        public Coordinate Location { get; set; }= new Coordinate();
        public string? RoadName { get; set; } 
        public string? Direction { get; set; } 
        public double? FlowRate { get; set; }
        public double? VehicleSpeed { get; set; }

        //public Status Status { get; set; }
        public DateTime? CreatedOn { get; set; }

        public static TrafficData Create(Guid eagleBotId,Coordinate location,string? roadName,string? direction,double? flowRate,double? vehicleSpeed,IClock clock)
        {
            var trafficData = new TrafficData
            {
                EagleBotId = eagleBotId,
                Location = location,
                RoadName = roadName,
                Direction = direction,                    
                FlowRate = flowRate,
                VehicleSpeed=vehicleSpeed,
                CreatedOn =clock.GetUtcNow()
            };
            //trafficData.AddDomainEvent(new TrafficDataCreated(trafficData, clock));
            return trafficData;
        }
    }
}
