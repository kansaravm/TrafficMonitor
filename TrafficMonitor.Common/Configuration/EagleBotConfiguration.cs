using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Common.Models;

namespace TrafficMonitor.Common.Configuration
{
    internal class EagleBotConfiguration : IEntityTypeConfiguration<EagleBot>
    {
        public void Configure(EntityTypeBuilder<EagleBot> builder)
        {
            builder.ToTable("EagleBot")
                .HasIndex(o => o.Id)
                .IsUnique();
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Timestamp).IsRowVersion();
            builder.Property(o => o.CreatedOn)
                .HasConversion(v => v, d => DateTime.SpecifyKind(d!.Value, DateTimeKind.Utc));
            builder.Property(o => o.Status).HasConversion<string>();


        }
    }
}
