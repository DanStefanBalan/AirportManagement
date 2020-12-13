using AirportManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Repo.Mappings
{
    public class AccountMapping
    {
        public AccountMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(account => account.Id);
        }
    }
}