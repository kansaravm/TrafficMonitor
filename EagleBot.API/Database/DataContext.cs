using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EagleBot.API.Database
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Models.EagleBot> EagleBot { get; set; }

    }
}
