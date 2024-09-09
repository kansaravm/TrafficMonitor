using MassTransit;
using TrafficMonitor.Infrastructure.Abstractions.EventBus;

namespace TrafficMonitor.API.Consumers
{
    public sealed class TrafficStatusConsumer : IConsumer<TraffficStatusEvent>
    {
        private readonly ILogger<TrafficStatusConsumer> _logger;
        public TrafficStatusConsumer(ILogger<TrafficStatusConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<TraffficStatusEvent> context)
        {
            _logger.LogInformation("Traffic created:{@Product}", context.Message);
            return Task.CompletedTask;
        }
    }
}
