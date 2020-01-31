using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class GateMapping
    {
        public GateMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gate>()
                .HasKey(g => g.Id);
        }
    }
}
