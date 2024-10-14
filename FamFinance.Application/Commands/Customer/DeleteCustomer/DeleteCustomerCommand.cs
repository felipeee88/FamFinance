using MediatR;

namespace FamFinance.Application.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
    }
}