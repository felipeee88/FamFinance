using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Domain.Entities.Product
                {
                    Name = request.Name,
                    Price = request.Price,
                    IsAvailable = request.IsAvailable,
                    CustomerId = request.CustomerId
                };

                await _productService.AddAsync(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
