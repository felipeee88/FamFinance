using FamFinance.Application.DTOs;
using MediatR;

namespace FamFinance.Application.Queries.Products.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
