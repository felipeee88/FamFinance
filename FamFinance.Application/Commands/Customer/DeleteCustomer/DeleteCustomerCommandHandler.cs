using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(request.CustomerId);
                if (customer == null) return false;

                await _customerService.RemoveAsync(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
