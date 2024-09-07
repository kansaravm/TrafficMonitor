using Microsoft.EntityFrameworkCore;

[Owned]
public sealed record Coordinate
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
   
}