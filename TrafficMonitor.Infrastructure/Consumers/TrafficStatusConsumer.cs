using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Infrastructure.Abstractions.EventBus;

namespace TrafficMonitor.Infrastructure.Consumers
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
