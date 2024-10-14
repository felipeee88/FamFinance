using FamFinance.Domain.Entities;
using FamFinance.Domain.Interfaces.Repositories;
using FamFinance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FamFinance.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(FamFinanceContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> FindByNameAsync(string name)
        {
            return await Db.Products.Where(p => p.Name == name).ToListAsync();
        }
    }
}
