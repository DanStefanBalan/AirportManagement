using System;
using System.Collections.Generic;
using System.Linq;
using AirportManagement.Data;
using AirportManagement.Repo;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AirportManagement.Service.Repository
{
    public interface IAirportService : IRepository<Airport>
    {
        IEnumerable<Airport> GetSameAirport(string name, string country, string city);
    }
}