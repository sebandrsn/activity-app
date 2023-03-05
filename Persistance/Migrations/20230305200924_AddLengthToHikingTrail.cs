using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddLengthToHikingTrail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "HikingTrails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "HikingTrails");
        }
    }
}
