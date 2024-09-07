using TrafficMonitor.Common.Models;

namespace TrafficMonitoring.BusinessLayer.Services
{
    public interface ITrafficDataService
    {
        Task CreateTrafficData(TrafficData request);
        //Task<TrafficData> GetTrafficData(TrafficData request);
        Task<List<TrafficData>> GetTrafficData();

    }
}
