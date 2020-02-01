using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportManagement.Repo.Migrations
{
    public partial class airport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircraft_Flight_FlightId",
                table: "Aircraft");

            migrationBuilder.DropForeignKey(
                name: "FK_Destination_Airport_AirportId",
                table: "Destination");

            migrationBuilder.DropForeignKey(
                name: "FK_Destination_Flight_FlightDestinationId",
                table: "Destination");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_AirportId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Gate_Destination_DestinationId",
                table: "Gate");

            migrationBuilder.DropForeignKey(
                name: "FK_Gate_Flight_FlightId",
                table: "Gate");

            migrationBuilder.DropForeignKey(
                name: "FK_Gate_Terminal_TerminalId",
                table: "Gate");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminal_Airport_AirportId",
                table: "Terminal");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminal_Destination_DestinationId",
                table: "Terminal");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminal_Flight_DestinationId",
                table: "Terminal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminal",
                table: "Terminal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gate",
                table: "Gate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airport",
                table: "Airport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft");

            migrationBuilder.RenameTable(
                name: "Terminal",
                newName: "Terminals");

            migrationBuilder.RenameTable(
                name: "Gate",
                newName: "Gates");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "Flights");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.RenameTable(
                name: "Airport",
                newName: "Airports");

            migrationBuilder.RenameTable(
                name: "Aircraft",
                newName: "Aircrafts");

            migrationBuilder.RenameIndex(
                name: "IX_Terminal_DestinationId",
                table: "Terminals",
                newName: "IX_Terminals_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Terminal_AirportId",
                table: "Terminals",
                newName: "IX_Terminals_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Gate_TerminalId",
                table: "Gates",
                newName: "IX_Gates_TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_Gate_FlightId",
                table: "Gates",
                newName: "IX_Gates_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Gate_DestinationId",
                table: "Gates",
                newName: "IX_Gates_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_AirportId",
                table: "Flights",
                newName: "IX_Flights_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Destination_FlightDestinationId",
                table: "Destinations",
                newName: "IX_Destinations_FlightDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Destination_AirportId",
                table: "Destinations",
                newName: "IX_Destinations_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircraft_FlightId",
                table: "Aircrafts",
                newName: "IX_Aircrafts_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminals",
                table: "Terminals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gates",
                table: "Gates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airports",
                table: "Airports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Flights_FlightId",
                table: "Aircrafts",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Airports_AirportId",
                table: "Destinations",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Flights_FlightDestinationId",
                table: "Destinations",
                column: "FlightDestinationId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Destinations_DestinationId",
                table: "Gates",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Flights_FlightId",
                table: "Gates",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Terminals_TerminalId",
                table: "Gates",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Airports_AirportId",
                table: "Terminals",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Destinations_DestinationId",
                table: "Terminals",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Flights_DestinationId",
                table: "Terminals",
                column: "DestinationId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Flights_FlightId",
                table: "Aircrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Airports_AirportId",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Flights_FlightDestinationId",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Destinations_DestinationId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Flights_FlightId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Terminals_TerminalId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Airports_AirportId",
                table: "Terminals");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Destinations_DestinationId",
                table: "Terminals");

            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Flights_DestinationId",
                table: "Terminals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminals",
                table: "Terminals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gates",
                table: "Gates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airports",
                table: "Airports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts");

            migrationBuilder.RenameTable(
                name: "Terminals",
                newName: "Terminal");

            migrationBuilder.RenameTable(
                name: "Gates",
                newName: "Gate");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "Flight");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.RenameTable(
                name: "Airports",
                newName: "Airport");

            migrationBuilder.RenameTable(
                name: "Aircrafts",
                newName: "Aircraft");

            migrationBuilder.RenameIndex(
                name: "IX_Terminals_DestinationId",
                table: "Terminal",
                newName: "IX_Terminal_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Terminals_AirportId",
                table: "Terminal",
                newName: "IX_Terminal_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Gates_TerminalId",
                table: "Gate",
                newName: "IX_Gate_TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_Gates_FlightId",
                table: "Gate",
                newName: "IX_Gate_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Gates_DestinationId",
                table: "Gate",
                newName: "IX_Gate_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AirportId",
                table: "Flight",
                newName: "IX_Flight_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_FlightDestinationId",
                table: "Destination",
                newName: "IX_Destination_FlightDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_AirportId",
                table: "Destination",
                newName: "IX_Destination_AirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircrafts_FlightId",
                table: "Aircraft",
                newName: "IX_Aircraft_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminal",
                table: "Terminal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gate",
                table: "Gate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airport",
                table: "Airport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircraft_Flight_FlightId",
                table: "Aircraft",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_Airport_AirportId",
                table: "Destination",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_Flight_FlightDestinationId",
                table: "Destination",
                column: "FlightDestinationId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_AirportId",
                table: "Flight",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gate_Destination_DestinationId",
                table: "Gate",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gate_Flight_FlightId",
                table: "Gate",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gate_Terminal_TerminalId",
                table: "Gate",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminal_Airport_AirportId",
                table: "Terminal",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminal_Destination_DestinationId",
                table: "Terminal",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Terminal_Flight_DestinationId",
                table: "Terminal",
                column: "DestinationId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
