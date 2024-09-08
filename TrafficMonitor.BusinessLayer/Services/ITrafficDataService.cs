using TrafficMonitor.Common.Models;
using X.PagedList;


namespace TrafficMonitoring.BusinessLayer.Services
{
    public interface ITrafficDataService
    {
        Task CreateTrafficData(TrafficData request);
        Task<IPagedList<TrafficData>> GetTrafficData(GetTrafficFilter filter);

    }
}
