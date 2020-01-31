using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Service.Repository
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights();
        Flight GetFlight(Guid id);
        void InsertFlight(Flight flight);
        void InsertFlights(IEnumerable<Flight> flights);
        void DeleteFlight(Guid id);
        void DeleteFlights(IEnumerable<Flight> flights);
        void UpdateFlight(Flight flight);
    }
}