using System;
using System.Collections.Generic;

namespace AirportManagement.Data
{
    public class Terminal : BaseEntity
    {
        public string Name { get; private set; }
        public Airport Airport { get; private set; }
        public Flight Flight { get; private set; }
        public Destination Destination { get; set; }
        public Guid? AirportId { get; private set; }
        public Guid? FlightId { get; private set; }
        public Guid? DestinationId { get; set; }
        public ICollection<Gate> Gates { get; private set; }
        public static Terminal Create(string name) => new Terminal()
        {
            Id = new Guid(),
            Name = name,
        };
    }

}