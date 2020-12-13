using System;
using AirportManagement.Data.Enums;

namespace AirportManagement.Data
{
    public class Destination : BaseEntity
    {
        public DateTime LocalTime { get; private set; }
        public WeatherType Weather { get; private set; }
        public Terminal Terminal { get; private set; }
        public Airport Airport { get; private set; }
        public Flight Flight { get; private set; }
        public Guid? FlightDestinationId { get; set; }


        public static Destination Create(DateTime localTime, WeatherType weather, Terminal terminal, Airport airport) =>
            new Destination()
            {
                Id = Guid.NewGuid(),
                LocalTime = localTime,
                Weather = weather,
                Terminal = terminal,
                Airport = airport
            };
    }
}