using System;

namespace AirportManagement.Data
{
    public class Aircraft : BaseEntity
    {
        public Flight Flight { get; private set; }
        public Guid? FlightId { get; private set; }
        public string AircraftType { get; private set; }
        public string CountryOfRegistration { get; private set; }
        public int NumberOfPilots { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public int NumberOfSeats { get; private set; }
        public int NumberOfFlightAttendants { get; private set; }

        public static Aircraft Create(string aircraftType, string countryOfRegistration, int numberOfPilots, string manufacturer, string model, int numberOfSeats, int numberOfFlightAttendants) => new Aircraft()
        {
            Id = new Guid(),
            AircraftType = aircraftType,
            CountryOfRegistration = countryOfRegistration,
            NumberOfPilots = numberOfPilots,
            Manufacturer = manufacturer,
            Model = model,
            NumberOfSeats = numberOfSeats,
            NumberOfFlightAttendants = numberOfFlightAttendants
        };

    }
}
