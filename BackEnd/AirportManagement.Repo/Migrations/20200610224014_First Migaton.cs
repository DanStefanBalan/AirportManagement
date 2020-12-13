using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportManagement.Repo.Migrations
{
    public partial class FirstMigaton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
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
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: true),
                    AircraftNumber = table.Column<string>(nullable: true),
                    CountryOfRegistration = table.Column<string>(nullable: true),
                    NumberOfPilots = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    NumberOfFlightAttendants = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircrafts_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
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
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinations_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Destinations_Flights_FlightDestinationId",
                        column: x => x.FlightDestinationId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GateNumber = table.Column<int>(nullable: false),
                    AirportId = table.Column<Guid>(nullable: true),
                    FlightId = table.Column<Guid>(nullable: true),
                    DestinationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminals_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminals_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Terminals_Flights_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_FlightId",
                table: "Aircrafts",
                column: "FlightId",
                unique: true,
                filter: "[FlightId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_AirportId",
                table: "Destinations",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_FlightDestinationId",
                table: "Destinations",
                column: "FlightDestinationId",
                unique: true,
                filter: "[FlightDestinationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_AirportId",
                table: "Terminals",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_DestinationId",
                table: "Terminals",
                column: "DestinationId",
                unique: true,
                filter: "[DestinationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
