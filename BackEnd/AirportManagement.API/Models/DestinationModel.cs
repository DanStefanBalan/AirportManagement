using System;
using AirportManagement.Data.Enums;

namespace AirportManagement.API.Models
{
    public class DestinationModel
    {
        public DateTime LocalTime { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public WeatherType Weather { get; set; }
        public TerminalModel Terminal { get; set; }
        public GateModel Gate { get; set; }

    }
}