using FluentValidation;
using OrderManagement.Core.Models.Requests;

namespace OrderManagement.Core.Validation
{
    public class CreateOrdRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrdRequestValidator()
        {
            RuleFor(c => c.OrderDate)
                .NotEmpty()
                .WithMessage("Order Date is required")
                .LessThan(DateTime.Now)
                .WithMessage("Order Date cannot be in the future");
            RuleFor(c => c.OrderNumber)
                .NotEmpty()
                .WithMessage("Order Number is required")
                .MaximumLength(10)
                .WithMessage("Order Number must be 10 characters or less");
            RuleFor(c => c.CustomerId)
                .Must(c => c > 0)
                .WithMessage("Customer Id should be above zero");
        }
    }
}
