using FamFinance.Application.Commands.Customer.CreateCustomer;
using FamFinance.Application.Commands.Customer.UpdateCustomer;
using FamFinance.Application.Commands.Customers.DeleteCustomer;
using FamFinance.Application.Commands.Product.CreateProduct;
using FamFinance.Application.Commands.Product.DeleteProduct;
using FamFinance.Application.Commands.Product.UpdateProduct;
using FamFinance.Application.Queries.Customers.GetCustomerById;
using FamFinance.Application.Queries.Products.GetProductById;
using FamFinance.Domain.Interfaces.Repositories;
using FamFinance.Domain.Interfaces.Services;
using FamFinance.Domain.Services;
using FamFinance.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FamFinance.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();

            #endregion

            #region Repositories

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            #region MediatR

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateCustomerCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteCustomerCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<GetCustomerByIdQueryHandler>();

                cfg.RegisterServicesFromAssemblyContaining<CreateProductCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateProductCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteProductCommandHandler>();
                cfg.RegisterServicesFromAssemblyContaining<GetProductByIdQueryHandler>();
            });

            #endregion

            return services;
        }
    }
}
