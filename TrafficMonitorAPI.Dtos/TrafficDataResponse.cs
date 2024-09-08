namespace TrafficMonitorAPI.Dtos
{
    public class TrafficDataResponse {
        public Guid EagleBotId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? RoadName { get; set; }
        public string? Direction { get; set; }
        public double? FlowRate { get; set; }
        public double? VehicleSpeed { get; set; }
       // public TrafficDataResponse() { }
    }

}
