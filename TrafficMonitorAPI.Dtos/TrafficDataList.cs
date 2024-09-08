using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficMonitor.Common.Models;

namespace TrafficMonitorAPI.Dtos
{
    public class TrafficDataList
    {
        public List<TrafficDataResponse> TrafficDataResponses { get; set; } =new List<TrafficDataResponse>();
        public Paging? Paging { get; set; }
    }
}
