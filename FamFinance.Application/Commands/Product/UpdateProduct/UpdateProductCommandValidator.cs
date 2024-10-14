using FluentValidation;

namespace FamFinance.Application.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");

            RuleFor(p => p.IsAvailable)
                .NotNull().WithMessage("Product availability must be specified.");
        }
    }
}
