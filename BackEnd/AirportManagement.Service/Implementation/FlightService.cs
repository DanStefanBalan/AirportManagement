using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class FlightService : Repository<Flight>,IFlightService
    {
        public FlightService(ApplicationContext dbContext): base(dbContext)
        {
            
        }   
    }
}