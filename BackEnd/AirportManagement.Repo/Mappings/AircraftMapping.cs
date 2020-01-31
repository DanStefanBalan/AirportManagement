using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class AircraftMapping
    {
        public AircraftMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>()
                .HasKey(aircraft => aircraft.Id);
        }
    }
}
