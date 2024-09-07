namespace TrafficMonitorAPI.Dtos
{
    public record TrafficDataRequest( Guid EagleBotId,double Latitude,double Longitude,string? RoadName,string Direction,double? FlowRate,double? VehicleSpeed);    
}
