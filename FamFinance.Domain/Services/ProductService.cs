using FamFinance.Domain.Entities;
using FamFinance.Domain.Interfaces.Repositories;
using FamFinance.Domain.Interfaces.Services;

namespace FamFinance.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> FindByNameAsync(string name)
        {
            return await _repository.FindByNameAsync(name);
        }
    }
}
