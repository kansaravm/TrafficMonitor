using Common.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Common;
using TrafficMonitor.Common.Models;

namespace TrafficMonitor.API.Consumers
{
    internal class EagleBotCreatedConsumer : IConsumer<EagleBotCreatedEvent>
    {
        private readonly TrafficMonitorDataContext _context;
        public EagleBotCreatedConsumer(TrafficMonitorDataContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<EagleBotCreatedEvent> context)
        {
            var eagleBot = new EagleBot
            {
                Id = context.Message.Id,
                CreatedOn = context.Message.CreatedOn,
                Name = context.Message.Name
            };
            _context.Add(eagleBot);
            await _context.SaveChangesAsync(default);
            
        }
    }
}
