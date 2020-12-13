using System;

namespace AirportManagement.Data
{
    public class Aircraft : BaseEntity
    {
        public Flight Flight { get; private set; }
        public Guid? FlightId { get; private set; }
        public string AircraftNumber { get; private set; }
        public string CountryOfRegistration { get; private set; }
        public int NumberOfPilots { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public int NumberOfSeats { get; private set; }
        public int NumberOfFlightAttendants { get; private set; }

        public static Aircraft Create(string aircraftNumber, string countryOfRegistration, int numberOfPilots, string manufacturer, string model, int numberOfSeats, int numberOfFlightAttendants) => new Aircraft()
        {
            Id = new Guid(),
            AircraftNumber = aircraftNumber,
            CountryOfRegistration = countryOfRegistration,
            NumberOfPilots = numberOfPilots,
            Manufacturer = manufacturer,
            Model = model,
            NumberOfSeats = numberOfSeats,
            NumberOfFlightAttendants = numberOfFlightAttendants
        };

        public void Update(string aircraftNumber, string countryOfRegistration, int numberOfPilots, string manufacturer, string model,
            int numberOfSeats, int numberOfFlightAttendants)
        {
            AircraftNumber = aircraftNumber;
            CountryOfRegistration = countryOfRegistration;
            NumberOfFlightAttendants = numberOfFlightAttendants;
            NumberOfPilots = numberOfPilots;
            Manufacturer = manufacturer;
            Model = model;
            NumberOfSeats = numberOfSeats;
        }

    }
}
