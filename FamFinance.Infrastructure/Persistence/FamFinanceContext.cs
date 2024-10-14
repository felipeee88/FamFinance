using FamFinance.Domain.Entities;
using FamFinance.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace FamFinance.Infrastructure.Persistence
{
    public class FamFinanceContext : DbContext
    {
        public FamFinanceContext(DbContextOptions<FamFinanceContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YourConnectionStringHere");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
