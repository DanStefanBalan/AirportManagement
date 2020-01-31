using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly IRepository<Flight> _flightRepository;

        public FlightService(IRepository<Flight> flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public void InsertFlights(IEnumerable<Flight> flights)
        {
            _flightRepository.InsertRange(flights);
        }

        public void DeleteFlight(Guid id)
        {
            var flight = _flightRepository.Get(id);
            if (flight != null)
            {
                _flightRepository.Delete(flight);
                _flightRepository.SaveChanges();
            }
        }

        public void DeleteFlights(IEnumerable<Flight> flights)
        {
            _flightRepository.DeleteRange(flights);
        }

        public Flight GetFlight(Guid id)
        {
            return _flightRepository.Get(id);
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _flightRepository.GetAll();
        }

        public void InsertFlight(Flight flight)
        {
            _flightRepository.Insert(flight);
        }

        public void UpdateFlight(Flight flight)
        {
            _flightRepository.Update(flight);
        }
    }
}