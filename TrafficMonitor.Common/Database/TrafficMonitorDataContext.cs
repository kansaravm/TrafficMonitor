using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TrafficMonitor.Common.Models;

namespace TrafficMonitor.Common
{
    public class TrafficMonitorDataContext : DbContext {

        public TrafficMonitorDataContext(DbContextOptions<TrafficMonitorDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public virtual DbSet<TrafficData> TrafficData { get; set; } = default!;
        public virtual DbSet<EagleBot> EagleBot { get; set; } = default!;

    }
}
