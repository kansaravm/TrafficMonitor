using TrafficMonitor.Common.Models;

namespace TrafficMonitoring.BusinessLayer.Services
{
    public interface IEagleBotService
    {     
        
        Task<EagleBot?> GetEagleBot(Guid id);

    }
}
