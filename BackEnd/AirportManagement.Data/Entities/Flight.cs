using System;
using AirportManagement.Data.Enums;

namespace AirportManagement.Data
{
    public class Flight : BaseEntity
    {
        public Airport Airport { get; private set; }
        public Aircraft Aircraft { get; private set; }
        public Destination Destination { get; private set; }
        public Terminal Terminal { get; private set; }
        public Gate Gate { get; private set; }
        public Guid? AirportId { get; private set; }
        public Guid? DestinationId { get; private set; }
        public string FlightNumber { get; private set; }
        public string Airline { get; private set; }
        public TimeSpan EstimationTime { get; private set; }
        public TimeSpan DepartureTime { get; private set; }
        public TimeSpan ArrivalTime { get; private set; }
        public TimeSpan FlightTime { get; private set; }
        public FlightStatus Status { get; private set; }





        public static Flight Create(string flightNumber, Aircraft aircraft, Destination destination, TimeSpan estimationTime, TimeSpan departureTime, TimeSpan arrivalTime, TimeSpan flightTime, FlightStatus status, Terminal terminal, Gate gate, string airline) => new Flight()
        {
            Id = new Guid(),
            Aircraft = aircraft,
            Airline = airline,
            ArrivalTime = arrivalTime,
            DepartureTime = departureTime,
            Destination = destination,
            FlightTime = flightTime,
            EstimationTime = estimationTime,
            FlightNumber = flightNumber,
            Gate = gate,
            Status = status,
            Terminal = terminal
        };

    }


}
