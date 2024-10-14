using FamFinance.Application.DTOs;
using MediatR;

namespace FamFinance.Application.Queries.Customers.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int CustomerId { get; set; }

        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
