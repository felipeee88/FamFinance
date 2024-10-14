using FamFinance.Application.DTOs;
using FamFinance.Domain.Interfaces.Services;
using MediatR;

namespace FamFinance.Application.Queries.Customers.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetByIdAsync(request.CustomerId);

            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                IsActive = customer.IsActive,
                RegistrationDate = customer.RegistrationDate
            };
        }
    }
}
