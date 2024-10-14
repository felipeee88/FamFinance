using MediatR;

namespace FamFinance.Application.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}