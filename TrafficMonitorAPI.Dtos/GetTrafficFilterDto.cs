namespace TrafficMonitorAPI.Dtos
{
    public class GetTrafficFilterDto
    {
        public Guid? EagleBotId { get; init; }       
        //public string? Status { get; set; }
        //public DateTime? FromDate { get; set; }
        //public DateTime? ToDate { get; set; }
        
        /// <summary>
        ///     One based page number for paged results
        /// </summary>
        /// <example>1</example>
        public int PageNumber { get; init; } = 1;
        
        /// <summary>
        ///     Page size
        /// </summary>
        /// <example>20</example>
        public int PageSize { get; init; } = 10;

    }
}