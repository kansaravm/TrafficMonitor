using TrafficMonitor.Common.Models.SeedWork;

namespace TrafficMonitor.Common.Models
{
    public class EagleRock :Entity    {
       
        public string? Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

    }
}
