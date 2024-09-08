using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficMonitor.Common.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrafficData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "TrafficData",
            columns: new[] { "Id", "EagleBotId", "Location_Latitude", "Location_Longitude", "RoadName", "Direction", "FlowRate", "VehicleSpeed", "CreatedOn", "Timestamp" },
            values: new object[,]
            {
                { Guid.NewGuid(), Guid.Parse("4b3d4911-5959-4620-867d-168e23a72c70"), 40.7128, -74.0060, "Broadway", "North", 150.0, 35.5, new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("4b3d4911-5959-4620-867d-168e23a72c70"), 34.0522, -118.2437, "Sunset Boulevard", "West", 120.0, 40.0, new DateTime(2024, 1, 1, 9, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("4b3d4911-5959-4620-867d-168e23a72c70"), 37.7749, -122.4194, "Market Street", "South", 200.0, 25.0, new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("4b3d4911-5959-4620-867d-168e23a72c70"), 51.5074, -0.1278, "Oxford Street", "East", 180.0, 30.0, new DateTime(2024, 1, 1, 11, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("4b3d4911-5959-4620-867d-168e23a72c70"), 48.8566, 2.3522, "Champs-Élysées", "North", 160.0, 28.0, new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("f8552549-69ac-4547-814b-70588d1d87a5"), 40.7128, -74.0060, "Broadway", "North", 150.0, 35.5, new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("f8552549-69ac-4547-814b-70588d1d87a5"), 34.0522, -118.2437, "Sunset Boulevard", "West", 120.0, 40.0, new DateTime(2024, 1, 1, 9, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("f8552549-69ac-4547-814b-70588d1d87a5"), 37.7749, -122.4194, "Market Street", "South", 200.0, 25.0, new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("6b1f7fef-3337-4f8b-9e4c-ac5f92fea738"), 51.5074, -0.1278, "Oxford Street", "East", 180.0, 30.0, new DateTime(2024, 1, 1, 11, 0, 0, DateTimeKind.Utc), new byte[0] },
                { Guid.NewGuid(), Guid.Parse("bd020ae6-52b1-48e7-b195-e90a59d992fe"), 48.8566, 2.3522, "Champs-Élysées", "North", 160.0, 28.0, new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc), new byte[0] }




            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "TrafficData",
            keyColumn: "Id",
            keyValues: new object[]
            {
                // Provide all the GUIDs used in the Up method
            });
        }
    }
}
