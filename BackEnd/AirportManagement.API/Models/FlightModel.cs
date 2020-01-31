using System;
using AirportManagement.Data.Enums;

namespace AirportManagement.API.Models
{
    public class FlightModel
    {
        public string FlightNumber { get; set; }
        public AircraftModel Aircraft { get; set; }
        public DestinationModel Destination { get; set; }
        public TimeSpan EstimationTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }
        public FlightStatus Status { get; set; }
        public TerminalModel Terminal { get; set; }
        public GateModel Gate { get; set; }
        public string Airline { get; set; }
    }
}