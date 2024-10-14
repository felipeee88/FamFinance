using FluentValidation;

namespace FamFinance.Application.Commands.Product.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");

            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(p => p.IsAvailable)
                .NotNull().WithMessage("Product availability must be specified.");
        }
    }
}
