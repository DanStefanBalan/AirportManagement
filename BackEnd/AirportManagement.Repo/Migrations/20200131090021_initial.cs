using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportManagement.Repo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AirportId = table.Column<Guid>(nullable: true),
                    DestinationId = table.Column<Guid>(nullable: true),
                    FlightNumber = table.Column<string>(nullable: true),
                    Airline = table.Column<string>(nullable: true),
                    EstimationTime = table.Column<TimeSpan>(nullable: false),
                    DepartureTime = table.Column<TimeSpan>(nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(nullable: false),
                    FlightTime = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: true),
                    AircraftType = table.Column<string>(nullable: true),
                    CountryOfRegistration = table.Column<string>(nullable: true),
                    NumberOfPilots = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    NumberOfFlightAttendants = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircraft_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocalTime = table.Column<DateTime>(nullable: false),
                    Weather = table.Column<int>(nullable: false),
                    AirportId = table.Column<Guid>(nullable: true),
                    FlightDestinationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destination_Airport_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Destination_Flight_FlightDestinationId",
                        column: x => x.FlightDestinationId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AirportId = table.Column<Guid>(nullable: true),
                    FlightId = table.Column<Guid>(nullable: true),
                    DestinationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminal_Airport_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminal_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Terminal_Flight_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: true),
                    DestinationId = table.Column<Guid>(nullable: true),
                    TerminalId = table.Column<Guid>(nullable: true),
                    GateNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gate_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gate_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gate_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_FlightId",
                table: "Aircraft",
                column: "FlightId",
                unique: true,
                filter: "[FlightId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_AirportId",
                table: "Destination",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_FlightDestinationId",
                table: "Destination",
                column: "FlightDestinationId",
                unique: true,
                filter: "[FlightDestinationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportId",
                table: "Flight",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Gate_DestinationId",
                table: "Gate",
                column: "DestinationId",
                unique: true,
                filter: "[DestinationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gate_FlightId",
                table: "Gate",
                column: "FlightId",
                unique: true,
                filter: "[FlightId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gate_TerminalId",
                table: "Gate",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_AirportId",
                table: "Terminal",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_DestinationId",
                table: "Terminal",
                column: "DestinationId",
                unique: true,
                filter: "[DestinationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Gate");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airport");
        }
    }
}
