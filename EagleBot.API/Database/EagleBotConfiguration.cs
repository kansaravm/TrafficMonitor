using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleBot.API.Database
{
    internal class EagleBotConfiguration : IEntityTypeConfiguration<Models.EagleBot>
    {
        public void Configure(EntityTypeBuilder<Models.EagleBot> builder)
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
