using MediatR;

namespace FamFinance.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
