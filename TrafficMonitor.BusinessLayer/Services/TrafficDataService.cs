using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using TrafficMonitor.Common;
using TrafficMonitor.Common.Models;
using TrafficMonitor.Common.Models.SeedWork;
using TrafficMonitoring.BusinessLayer.Services;
using X.PagedList;


namespace TrafficMonitor.BusinessLayer.Services
{
    public class TrafficDataService : ITrafficDataService
    {
        private readonly TrafficMonitorDataContext _context;
        public ILogger<TrafficDataService> _logger;
        private readonly IClock _clock;

        public TrafficDataService(TrafficMonitorDataContext context, ILogger<TrafficDataService> logger,IClock clock)
        {
            _context = context;
            _logger = logger;
            _clock = clock;
        }
        public async Task CreateTrafficData(TrafficData request)
        {
           // var traffiData = TrafficData.Create(request.EagleBotId, request.Location, request.RoadName, request.Direction, request.FlowRate, request.VehicleSpeed, _clock);
            await _context.TrafficData.AddAsync(request);
            await _context.SaveChangesAsync();
           
        }

        //public async Task<List<TrafficData>> GetTrafficData()
        //{
        //    return await _context.TrafficData.ToListAsync();
        //}

        public async Task<IPagedList<TrafficData>> GetTrafficData(GetTrafficFilter filter)
        {
            var query = _context.TrafficData.AsQueryable();
            if (filter.HasEagleBotId())
                query = query.Where(r => r.EagleBotId == filter.EagleBotId);
            return await query.AsSplitQuery().
            OrderByDescending(r => r.CreatedOn).ToPagedListAsync(filter.PageNumber, filter.PageSize);
        }

       
    }
}
