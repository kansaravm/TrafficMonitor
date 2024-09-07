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
        public  DbSet<TrafficData> TrafficData { get; set; } 
        public  DbSet<EagleBot> EagleBot { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
