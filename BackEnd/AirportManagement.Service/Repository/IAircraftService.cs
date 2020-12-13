using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;

namespace AirportManagement.Service.Repository
{
    public interface IAircraftService: IRepository<Aircraft>
    {
        IReadOnlyCollection<string> GetAircraftsNumber();
    }
}