using FamFinance.Domain.Entities;

namespace FamFinance.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<IEnumerable<Product>> FindByNameAsync(string name);
    }
}
