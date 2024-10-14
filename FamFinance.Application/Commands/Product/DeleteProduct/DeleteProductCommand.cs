using MediatR;

namespace FamFinance.Application.Commands.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
    }
}
