using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrafficMonitor.Common;
using TrafficMonitor.Common.Models;
using TrafficMonitoring.BusinessLayer.Services;

namespace TrafficMonitor.BusinessLayer.Services
{
    public class EagleBotService : IEagleBotService
    {
        private readonly TrafficMonitorDataContext _context;
        public ILogger<EagleBotService> _logger;
        public EagleBotService(TrafficMonitorDataContext context, ILogger<EagleBotService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<EagleBot?> GetEagleBot(Guid eagleBotId)
        {
            return await _context.EagleBot.AsNoTracking().SingleOrDefaultAsync(s=>s.Id==eagleBotId);

        }
    }

        
}
