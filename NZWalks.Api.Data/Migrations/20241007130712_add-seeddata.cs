using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Climate", "CreatedOn", "LastUpdatedOn", "Name" },
                values: new object[] { 1, 1, new DateTime(2024, 10, 7, 15, 7, 12, 611, DateTimeKind.Local).AddTicks(7533), new DateTime(2024, 10, 7, 15, 7, 12, 611, DateTimeKind.Local).AddTicks(7608), "White Cap Bay" });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Altidude", "CreatedOn", "Description", "LastUpdatedOn", "LengthInKm", "Name", "PictureUrl", "RegionId", "Score" },
                values: new object[,]
                {
                    { 1, 123, new DateTime(2024, 10, 7, 15, 7, 12, 611, DateTimeKind.Local).AddTicks(7654), "lorem ipsum", new DateTime(2024, 10, 7, 15, 7, 12, 611, DateTimeKind.Local).AddTicks(7657), 10.0, "Dummy", "www.google.be", 1, 1 },
                    { 2, 6000, new DateTime(2024, 10, 7, 15, 7, 12, 611, DateTimeKind.Local).AddTicks(7662), "lorem", new DateTime(2024, 10, 7, 15, 7, 12, 611, DateTimeKind.Local).AddTicks(7664), 14.0, "Another Dummy", "www.yahoo.be", 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}