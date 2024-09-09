using TrafficMonitor.Common.Models.SeedWork;

namespace EagleBot.API.Models
{
    public class EagleBot : Entity, IAggregateRoot
    {
        public string? Name { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
