using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampingSpots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CoordinatesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampingSpots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampingSpots_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HikingTrails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CoordinatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HikingTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HikingTrails_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MountainbikeTrails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CoordinatesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainbikeTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainbikeTrails_Coordinates_CoordinatesId",
                        column: x => x.CoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampingSpots_CoordinatesId",
                table: "CampingSpots",
                column: "CoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_HikingTrails_CoordinatesId",
                table: "HikingTrails",
                column: "CoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainbikeTrails_CoordinatesId",
                table: "MountainbikeTrails",
                column: "CoordinatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CampingSpots");

            migrationBuilder.DropTable(
                name: "HikingTrails");

            migrationBuilder.DropTable(
                name: "MountainbikeTrails");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
