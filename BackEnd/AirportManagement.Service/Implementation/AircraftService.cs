using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class AircraftService : IAircraftService
    {
        private readonly IRepository<Aircraft> _aircraftRepository;

        public AircraftService(IRepository<Aircraft> aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        public void DeleteAircraft(Guid id)
        {
            var aircraft = _aircraftRepository.Get(id);
            if (aircraft != null)
            {
                _aircraftRepository.Delete(aircraft);
                _aircraftRepository.SaveChanges();
            }
        }

        public void DeleteAircrafts(IEnumerable<Aircraft> aircrafts)
        {
            _aircraftRepository.DeleteRange(aircrafts);
        }

        public Aircraft GetAircraft(Guid id)
        {
            return _aircraftRepository.Get(id);
        }

        public IEnumerable<Aircraft> GetAircrafts()
        {
            return _aircraftRepository.GetAll();
        }

        public void InsertAircraft(Aircraft aircraft)
        {
            _aircraftRepository.Insert(aircraft);
        }

        public void InsertAircrafts(IEnumerable<Aircraft> aircrafts)
        {
            _aircraftRepository.InsertRange(aircrafts);
        }

        public void UpdateAircraft(Aircraft aircraft)
        {
            _aircraftRepository.Update(aircraft);
        }
    }
}