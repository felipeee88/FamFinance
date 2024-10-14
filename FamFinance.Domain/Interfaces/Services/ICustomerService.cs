using FamFinance.Domain.Entities;

namespace FamFinance.Domain.Interfaces.Services
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        Task<IEnumerable<Customer>> GetSpecialCustomersAsync(IEnumerable<Customer> customers);
    }
}
