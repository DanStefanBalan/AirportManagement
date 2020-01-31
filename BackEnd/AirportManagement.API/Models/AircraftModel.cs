namespace AirportManagement.API.Models
{
    public class AircraftModel
    {
        public string AircraftType { get; set; }
        public string CountryOfRegistration { get; set; }
        public int NumberOfPilots { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfFlightAttendants { get; set; }
    }
}