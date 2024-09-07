using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficMonitor.Common.Models;

namespace TrafficMonitor.Common.Configuration
{
    internal class TrafficDataConfiguration : IEntityTypeConfiguration<TrafficData>
    {
        public void Configure(EntityTypeBuilder<TrafficData> builder)
        {
            builder.ToTable("TrafficData")
                .HasIndex(o => o.Id)
                .IsUnique();
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Timestamp).IsRowVersion();
            builder.Property(o=> o.CreatedOn)
                .HasConversion(v=>v,d=>DateTime.SpecifyKind(d!.Value, DateTimeKind.Utc));
            builder.Property(O => O.Direction).HasConversion<string>();
              

        }
    }
}
