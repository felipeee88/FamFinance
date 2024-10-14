using FamFinance.Application.DTOs;
using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Queries.Products.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                CustomerId = product.CustomerId
            };
        }
    }
}
