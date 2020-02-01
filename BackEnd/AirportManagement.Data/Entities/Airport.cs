using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AirportManagement.Data
{
    public class Airport : BaseEntity
    {
        public ICollection<Flight> Flights { get; private set; }
        public ICollection<Terminal> Terminals { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }

        public static Airport Create(string name, string country, string city) => new Airport()
        {
            Id = new Guid(),
            Flights = new List<Flight>(),
            Terminals = new List<Terminal>(),
            Name = name,
            Country = country,
            City = city
        };

        public void Update(string name, string country, string city)
        {
            Name = name;
            Country = country;
            City = city;
        }
    }
}
