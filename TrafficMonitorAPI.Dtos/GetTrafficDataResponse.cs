using TrafficMonitor.Common.Models;

namespace TrafficMonitorAPI.Dtos
{
    public class GetTrafficDataResponse
    {
        public List<TrafficDataResponse> TrafficDataResponses { get; set; } =new List<TrafficDataResponse>();
        public Paging? Paging { get; set; }
    }
}
