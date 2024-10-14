using FamFinance.Domain.Interfaces.Repositories;
using FamFinance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FamFinance.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly FamFinanceContext Db;

        public RepositoryBase(FamFinanceContext context)
        {
            Db = context;
        }

        public async Task AddAsync(TEntity obj)
        {
            await Db.Set<TEntity>().AddAsync(obj);
            await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Db.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            await Db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            Db.Set<TEntity>().Update(obj);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
