using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp2.Migrations
{
    /// <inheritdoc />
    public partial class wip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPilot");

            migrationBuilder.CreateTable(
                name: "FlightPilots",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false),
                    PilotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPilots", x => new { x.FlightId, x.PilotId });
                    table.ForeignKey(
                        name: "FK_FlightPilots_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPilots_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPilots_PilotId",
                table: "FlightPilots",
                column: "PilotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPilots");

            migrationBuilder.CreateTable(
                name: "FlightPilot",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "INTEGER", nullable: false),
                    PilotsPilotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPilot", x => new { x.FlightsFlightId, x.PilotsPilotId });
                    table.ForeignKey(
                        name: "FK_FlightPilot_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPilot_Pilots_PilotsPilotId",
                        column: x => x.PilotsPilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPilot_PilotsPilotId",
                table: "FlightPilot",
                column: "PilotsPilotId");
        }
    }
}
