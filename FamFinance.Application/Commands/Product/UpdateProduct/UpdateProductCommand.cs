using MediatR;

namespace FamFinance.Application.Commands.Product.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
