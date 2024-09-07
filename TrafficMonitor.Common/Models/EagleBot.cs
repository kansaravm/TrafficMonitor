
using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.Models
{
    public class EagleBot :Entity
    {     
        public string Name { get; set; }      

        public DateTime Created { get; set; }
        public List<TrafficData> TrafficData { get; set; } = new();
        
    }
}
