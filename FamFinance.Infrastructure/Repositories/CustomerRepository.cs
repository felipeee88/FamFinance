using FamFinance.Domain.Entities;
using FamFinance.Domain.Interfaces.Repositories;
using FamFinance.Infrastructure.Persistence;

namespace FamFinance.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(FamFinanceContext context) : base(context)
        {
        }
    }
}
