namespace TrafficMonitor.Common.Models.SeedWork
{
    public sealed class SystemClock : IClock
    {
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}
