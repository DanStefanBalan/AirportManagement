using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Service.Repository
{
    public interface IAircraftService
    {
        IEnumerable<Aircraft> GetAircrafts();
        Aircraft GetAircraft(Guid id);
        void InsertAircraft(Aircraft aircraft);
        void InsertAircrafts(IEnumerable<Aircraft> aircrafts);
        void UpdateAircraft(Aircraft aircraft);
        void DeleteAircraft(Guid id);
        void DeleteAircrafts(IEnumerable<Aircraft> aircrafts);
    }
}