using FluentValidation;
using OrderManagement.Core.Models.Requests;

namespace OrderManagement.Core.Validation
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.");
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\+?(\d{12})$")
                .WithMessage("Invalid phone number format. It should be 12 digits long (066 included).");
        }
    }
}
