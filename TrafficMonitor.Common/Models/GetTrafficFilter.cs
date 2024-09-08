namespace TrafficMonitor.Common.Models
{
    public class GetTrafficFilter
    {
        public Guid? EagleBotId { get; init; }
        //public string? Status { get; init; }
        //public DateTime? FromDate { get; init; }
        //public DateTime? ToDate { get; init; }
        //filter by roadname in future
        // public string? Contains { get; init; }
        public int PageSize { get; init; } = 10;
        public int PageNumber { get; init; } = 1;

        public bool HasEagleBotId()=>EagleBotId.HasValue;
        //public bool HasFromDate()=> FromDate.HasValue;
        //public bool HasToDate() => ToDate.HasValue;


    }
}
    
