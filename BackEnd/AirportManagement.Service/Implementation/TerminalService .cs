using System;
using System.Collections.Generic;
using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class TerminalService : Repository<Terminal>, ITerminalService
    {
        public TerminalService(ApplicationContext dbContext): base(dbContext)
        {
            
        }
    }
}