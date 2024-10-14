using FamFinance.Domain.Entities;

namespace FamFinance.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> FindByNameAsync(string name);
    }
}
