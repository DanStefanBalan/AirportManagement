using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class AirportMapping
    {
        public AirportMapping(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Airport>()
                .HasMany<Terminal>(t => t.Terminals)
                .WithOne(a => a.Airport)
                .HasForeignKey(t => t.AirportId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Airport>()
                .HasMany<Flight>(f => f.Flights)
                .WithOne(a => a.Airport)
                .HasForeignKey(f => f.AirportId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
