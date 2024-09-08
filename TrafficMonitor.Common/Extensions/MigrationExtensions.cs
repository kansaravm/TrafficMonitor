using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficMonitor.Common.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope= app.ApplicationServices.CreateScope();
            using TrafficMonitorDataContext dbContext= scope.ServiceProvider.GetRequiredService<TrafficMonitorDataContext>();

            dbContext.Database.Migrate();
        }
    }
}
