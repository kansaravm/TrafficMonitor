﻿using TrafficMonitor.Common.Models;
using X.PagedList;


namespace TrafficMonitoring.BusinessLayer.Services
{
    public interface ITrafficDataService
    {
        Task CreateTrafficData(TrafficData request);
        Task<IPagedList<TrafficData>> GetTrafficData(GetTrafficFilter filter);
        Task<IPagedList<TrafficData>> GetTrafficDataWithCaching(GetTrafficFilter filter, CancellationToken cancellationToken = default);
        Task<EagleBot?> GetEagleBot(Guid eagleBotId);
    }
}
