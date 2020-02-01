using System;

namespace AirportManagement.API.Models
{
    public class AirportModel
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}