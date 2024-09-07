using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrafficMonitor.Common;
using TrafficMonitor.Common.Models;
using TrafficMonitoring.BusinessLayer.Services;

namespace TrafficMonitor.BusinessLayer.Services
{
    public class TrafficDataService : ITrafficDataService
    {
        private readonly TrafficMonitorDataContext _context;
        public ILogger<TrafficDataService> _logger;
        public TrafficDataService(TrafficMonitorDataContext context, ILogger<TrafficDataService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task CreateTrafficData(TrafficData request)
        {
            await _context.TrafficData.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TrafficData>> GetTrafficData()
        {
            return await _context.TrafficData.ToListAsync();
        }

        //public async Task<TrafficData> GetTrafficData(TrafficData request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
