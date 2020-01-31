using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Service.Repository
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAirports();
        Airport GetAirport(Guid id);
        void InsertAirport(Airport airport);
        void InsertAirports(IEnumerable<Airport> airports);
        void DeleteAirport(Guid id);
        void DeleteAirports(IEnumerable<Airport> airports);
        void UpdateAirport(Airport airport);
    }
}