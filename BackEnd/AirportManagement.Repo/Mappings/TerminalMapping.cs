using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class TerminalMapping
    {
        public TerminalMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>()
                .HasMany<Gate>(t => t.Gates)
                .WithOne(g => g.Terminal)
                .HasForeignKey(t => t.TerminalId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
