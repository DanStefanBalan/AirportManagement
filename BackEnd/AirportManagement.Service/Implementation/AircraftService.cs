using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Service.Implementation
{
    public class AircraftService : Repository<Aircraft>, IAircraftService
    {
        public AircraftService(ApplicationContext dbContext) : base(dbContext)
        {
            
        }
    }
}