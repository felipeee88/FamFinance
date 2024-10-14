using MediatR;

namespace FamFinance.Application.Commands.Product.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CustomerId { get; set; }
    }
}
