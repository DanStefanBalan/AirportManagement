using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class FlightMapping
    {
        public FlightMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne<Aircraft>(a => a.Aircraft)
                .WithOne(f => f.Flight)
                .HasForeignKey<Aircraft>(a => a.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne<Destination>(f => f.Destination)
                .WithOne(d => d.Flight)
                .HasForeignKey<Destination>(f => f.FlightDestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne<Terminal>(t => t.Terminal)
                .WithOne(t => t.Flight)
                .HasForeignKey<Terminal>(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
