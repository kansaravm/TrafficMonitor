using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficMonitor.Common.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EagleBot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EagleBot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrafficData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EagleBotId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location_Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Location_Longitude = table.Column<double>(type: "double precision", nullable: false),
                    RoadName = table.Column<string>(type: "text", nullable: true),
                    Direction = table.Column<string>(type: "text", nullable: true),
                    FlowRate = table.Column<double>(type: "double precision", nullable: true),
                    VehicleSpeed = table.Column<double>(type: "double precision", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EagleBot_Id",
                table: "EagleBot",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrafficData_Id",
                table: "TrafficData",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EagleBot");

            migrationBuilder.DropTable(
                name: "TrafficData");
        }
    }
}
