using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class GateService :Repository<Gate>, IGateService
    {
        public GateService(ApplicationContext dbContext) : base(dbContext)
        {
            
        }
    }
}