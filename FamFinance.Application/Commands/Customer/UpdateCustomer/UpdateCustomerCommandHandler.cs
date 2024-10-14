using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(request.CustomerId);

                if (customer == null) return false;

                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.Email = request.Email;
                customer.IsActive = request.IsActive;

                await _customerService.UpdateAsync(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
