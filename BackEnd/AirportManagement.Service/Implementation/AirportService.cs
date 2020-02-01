using System.Collections.Generic;
using System.Linq;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class AirportService : Repository<Airport>, IAirportService
    {
        public AirportService(ApplicationContext context)
            : base(context)
        {
        }

        public IEnumerable<Airport> GetSameAirport(string name, string country, string city)
        {
            return Context.Set<Airport>().Where(a => a.Name == name && a.Country == country && a.City == city).ToList();
        }
    }
}