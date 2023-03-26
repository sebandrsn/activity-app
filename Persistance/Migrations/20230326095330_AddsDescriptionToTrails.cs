using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddsDescriptionToTrails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MountainbikeTrails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HikingTrails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MountainbikeTrails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HikingTrails");
        }
    }
}
