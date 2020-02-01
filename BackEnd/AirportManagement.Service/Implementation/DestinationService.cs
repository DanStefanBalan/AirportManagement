using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class DestinationService : Repository<Destination>, IDestinationService
    {
        public DestinationService(ApplicationContext dbContext) : base(dbContext)
        {
            
        }
    }
}