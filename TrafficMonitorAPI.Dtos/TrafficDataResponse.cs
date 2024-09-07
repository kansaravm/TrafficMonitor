namespace TrafficMonitorAPI.Dtos
{
    public record TrafficDataResponse(Guid EagleBotId, double Latitude, double Longitude, string? RoadName, string Direction, double? FlowRate, double? VehicleSpeed);
}
