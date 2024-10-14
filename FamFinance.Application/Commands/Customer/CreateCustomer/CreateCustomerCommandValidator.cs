using FluentValidation;

namespace FamFinance.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
        }
    }
}
