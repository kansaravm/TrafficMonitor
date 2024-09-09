using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TrafficMonitor.Common;
using TrafficMonitor.Common.Models;
using TrafficMonitor.Common.Models.SeedWork;
using TrafficMonitor.Infrastructure.Abstractions;
using TrafficMonitoring.BusinessLayer.Services;
using X.PagedList;


namespace TrafficMonitor.BusinessLayer.Services
{
    public class TrafficDataService : ITrafficDataService
    {
        private readonly TrafficMonitorDataContext _context;
        public ILogger<TrafficDataService> _logger;
        private readonly ICacheService _cacheService;
        private readonly IClock _clock;

        public TrafficDataService(TrafficMonitorDataContext context, ILogger<TrafficDataService> logger,ICacheService cacheService,IClock clock)
        {
            _context = context;
            _logger = logger;
            _cacheService = cacheService;
            _clock = clock;
        }
        public async Task CreateTrafficData(TrafficData request)
        {
            var traffiData = TrafficData.Create(request.EagleBotId, request.Location, request.RoadName, request.Direction, request.FlowRate, request.VehicleSpeed, _clock);
            await _context.TrafficData.AddAsync(traffiData);
            await _context.SaveChangesAsync();           
        }

        public async Task<IPagedList<TrafficData>> GetTrafficData(GetTrafficFilter filter)
        {
            var query = _context.TrafficData.AsQueryable();
            if (filter.HasEagleBotId())
                query = query.Where(r => r.EagleBotId == filter.EagleBotId).OrderByDescending(r => r.CreatedOn);

            var totalRowCount = await query.CountAsync();
            var currentPage = await query.ToPagedListAsync(filter.PageNumber, filter.PageSize);
            return new StaticPagedList<TrafficData>(
                currentPage,
                filter.PageNumber,
                filter.PageSize,
                totalRowCount);
        }

        public async Task<IPagedList<TrafficData>> GetTrafficDataWithCaching(GetTrafficFilter filter,CancellationToken cancellationToken=default)
        {
            string cacheValue = JsonSerializer.Serialize(filter);
            return await _cacheService.GetAsync(cacheValue,
                async () =>
                {
                    var query = _context.TrafficData.AsQueryable();
                    if (filter.HasEagleBotId())
                        query = query.Where(r => r.EagleBotId == filter.EagleBotId).OrderByDescending(r => r.CreatedOn);

                    var totalRowCount = await query.CountAsync();
                    var currentPage = await query.ToPagedListAsync(filter.PageNumber, filter.PageSize);
                    IPagedList<TrafficData> response = new StaticPagedList<TrafficData>(
                        currentPage,
                        filter.PageNumber,
                        filter.PageSize,
                        totalRowCount);
                    return response;

                }, cancellationToken);


        }
    }
}
