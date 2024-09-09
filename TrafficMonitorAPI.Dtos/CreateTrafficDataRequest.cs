namespace TrafficMonitorAPI.Dtos
{
    //public record TrafficDataRequestDto( Guid EagleBotId,double Latitude,double Longitude,string? RoadName,string Direction,double? FlowRate,double? VehicleSpeed);    
    /// <summary>
    /// TrafficRequest
    /// </summary>
    public class CreateTrafficDataRequest
    {
        /// <summary>
        /// EagleBotId
        /// </summary>
        public Guid EagleBotId { get; set; } = default!;
        //public CoordinateDto Location { get; set; } = new CoordinateDto();
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? RoadName { get; set; }
        public string? Direction { get; set; }
        public double? FlowRate { get; set; }
        public double? VehicleSpeed { get; set; }

        //public Status Status { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
