using System.Collections.Generic;
using System.Linq;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class AircraftService : Repository<Aircraft>, IAircraftService
    {
        public AircraftService(ApplicationContext dbContext) : base(dbContext)
        {
            
        }

        public IReadOnlyCollection<string> GetAircraftsNumber()
        {
            return Context.Set<Aircraft>().Select(a => a.AircraftNumber).ToList();
        }

    }
}