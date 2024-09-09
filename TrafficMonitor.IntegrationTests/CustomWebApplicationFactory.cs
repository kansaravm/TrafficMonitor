using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using TrafficMonitor.Common;
using Microsoft.EntityFrameworkCore;

namespace TrafficMonitor.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TrafficMonitorDataContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add an in-memory database for testing.
                services.AddDbContext<TrafficMonitorDataContext>(options =>
                {
                    options.UseSqlite("Data Source=TrafficMonitorDB");
                });

                // Build the service provider.
                var serviceProvider = services.BuildServiceProvider();

                // Create a scope to get a reference to the database context (ApplicationDbContext).
                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<TrafficMonitorDataContext>();
                    db.Database.OpenConnection();
                    // Ensure the database is created.
                    db.Database.EnsureCreated();
                }
            });
        }
    }

}
