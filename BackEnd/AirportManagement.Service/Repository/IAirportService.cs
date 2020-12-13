using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;

namespace AirportManagement.Service.Repository
{
    public interface IAirportService : IRepository<Airport>
    {
        IEnumerable<Airport> GetSameAirport(string name, string country, string city);
    }
}