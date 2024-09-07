
using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.Models
{
    public class EagleBot :Entity
    {     
        public string? Name { get; set; }      

        public Status Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<TrafficData> TrafficData { get; set; } = new();
        
    }
}
