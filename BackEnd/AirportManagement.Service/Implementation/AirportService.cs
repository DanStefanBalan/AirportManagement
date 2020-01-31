using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class AirportService : IAirportService
    {
        private readonly IRepository<Airport> _airportRepository;

        public AirportService(IRepository<Airport> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public IEnumerable<Airport> GetAirports()
        {
            return _airportRepository.GetAll();
        }

        public Airport GetAirport(Guid id)
        {
            return _airportRepository.Get(id);
        }

        public void InsertAirport(Airport airport)
        {
            _airportRepository.Insert(airport);
        }

        public void InsertAirports(IEnumerable<Airport> airports)
        {
            _airportRepository.InsertRange(airports);
        }

        public void DeleteAirports(IEnumerable<Airport> airports)
        {
            _airportRepository.DeleteRange(airports);
        }

        public void UpdateAirport(Airport airport)
        {
            _airportRepository.Update(airport);
        }

        public void DeleteAirport(Guid id)
        {
            Airport airport = GetAirport(id);
            _airportRepository.Delete(airport);
            _airportRepository.SaveChanges();
        }
    }
}