using FluentValidation;

namespace FamFinance.Application.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
        }
    }
}
