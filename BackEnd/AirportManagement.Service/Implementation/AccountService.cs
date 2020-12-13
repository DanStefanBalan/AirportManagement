using AirportManagement.Data;
using AirportManagement.Repo;
using AirportManagement.Service.Repository;

namespace AirportManagement.Service.Implementation
{
    public class AccountService : Repository<Account> , IAccountService
    {
        public AccountService(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}