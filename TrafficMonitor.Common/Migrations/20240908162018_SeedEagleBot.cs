using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrafficMonitor.Common.Migrations
{
    /// <inheritdoc />
    public partial class SeedEagleBot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "EagleBot",
           columns: new[] { "Id", "Name", "Status", "CreatedOn", "Timestamp" },
           values: new object[,]
           {
                { "4b3d4911-5959-4620-867d-168e23a72c70", "EagleBot One", "Active", new DateTime(2024, 1, 15, 8, 30, 0, DateTimeKind.Utc), new byte[0] },
                { "f8552549-69ac-4547-814b-70588d1d87a5", "EagleBot Two", "Inactive", new DateTime(2024, 1, 16, 9, 45, 0, DateTimeKind.Utc), new byte[0] },
                { "d3ca0a51-17ce-4fb1-b645-c54070939815", "EagleBot Three", "Pending", new DateTime(2024, 1, 17, 10, 0, 0, DateTimeKind.Utc), new byte[0] },
                { "6b1f7fef-3337-4f8b-9e4c-ac5f92fea738", "EagleBot Four", "Active", new DateTime(2024, 1, 18, 11, 15, 0, DateTimeKind.Utc), new byte[0] },
                { "bd020ae6-52b1-48e7-b195-e90a59d992fe", "EagleBot Five", "Error", new DateTime(2024, 1, 19, 12, 30, 0, DateTimeKind.Utc), new byte[0] }
           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
           table: "EagleBot",
           keyColumn: "Id",
           keyValues: new object[]
           {
               // Provide all the GUIDs used in Up method
           });
        }
    }
}
