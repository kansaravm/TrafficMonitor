namespace TrafficMonitor.Infrastructure.Abstractions.EventBus
{
    public record TraffficStatusEvent
    {
        public Guid EagleBotId { get; init; }
        public string Status { get; init; } = string.Empty;
        public string RoadName { get; init; } =string.Empty;
    }
}
