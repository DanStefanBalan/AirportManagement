using Microsoft.EntityFrameworkCore;
using AirportManagement.Repo.Mappings;

namespace AirportManagement.Repo
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AirportMapping(modelBuilder);
            new AircraftMapping(modelBuilder);
            new DestinationMapping(modelBuilder);
            new FlightMapping(modelBuilder);
            new GateMapping(modelBuilder);
            new TerminalMapping(modelBuilder);
        }
    }
}
