using FamFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamFinance.Infrastructure.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}
