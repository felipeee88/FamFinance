using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Domain.Entities.Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    RegistrationDate = DateTime.Now,
                    IsActive = true
                };

                await _customerService.AddAsync(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
