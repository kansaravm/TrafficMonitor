using Microsoft.EntityFrameworkCore;
using TrafficMonitor.Common.Models;

namespace TrafficMonitor.Common
{
    public class TrafficMonitorDataContext : DbContext {

        public TrafficMonitorDataContext(DbContextOptions<TrafficMonitorDataContext> options)
            : base(options)
        {
        }

        public DbSet<TrafficData> TrafficData { get; set; }

}
}
