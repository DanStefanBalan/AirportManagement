using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;
using AirportManagement.Repo.Mappings;

namespace AirportManagement.Repo
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }


        public DbSet<Airport> Airports { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Terminal> Terminals { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AirportMapping(modelBuilder);
            new AircraftMapping(modelBuilder);
            new AccountMapping(modelBuilder);
            new DestinationMapping(modelBuilder);
            new FlightMapping(modelBuilder);
            new TerminalMapping(modelBuilder);
            new AccountMapping(modelBuilder);
        }
    }
}
