using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class DestinationMapping
    {
        public DestinationMapping(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Destination>()
                .HasOne<Terminal>(d => d.Terminal)
                .WithOne(t => t.Destination)
                .HasForeignKey<Terminal>(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
