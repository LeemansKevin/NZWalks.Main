using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class addscore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Walks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Walks");
        }
    }
}