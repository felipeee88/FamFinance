using FamFinance.Domain.Entities;
using FamFinance.Domain.Interfaces.Repositories;
using FamFinance.Domain.Interfaces.Services;

namespace FamFinance.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetSpecialCustomersAsync(IEnumerable<Customer> customers)
        {
            return await Task.Run(() => customers.Where(c => c.IsSpecialCustomer(c)));
        }
    }
}
