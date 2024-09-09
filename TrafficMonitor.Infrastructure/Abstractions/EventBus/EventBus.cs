

using MassTransit;

namespace TrafficMonitor.Infrastructure.Abstractions.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class =>
            _publishEndpoint.Publish(message,cancellationToken);
        
    }
}
