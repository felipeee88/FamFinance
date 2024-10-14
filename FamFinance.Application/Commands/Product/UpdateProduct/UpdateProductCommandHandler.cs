using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productService.GetByIdAsync(request.ProductId);
                if (product == null) return false;

                product.Name = request.Name;
                product.Price = request.Price;
                product.IsAvailable = request.IsAvailable;

                await _productService.UpdateAsync(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
