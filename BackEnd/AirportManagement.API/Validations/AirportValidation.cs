using AirportManagement.API.Models;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class AirportValidation : AbstractValidator<AirportModel>
    {
        public AirportValidation()
        {
            RuleFor(a => a.Name)
                .MinimumLength(3)
                .Matches("^[a-zA-Z]+$").WithMessage("Airport name should have just letters")
                .NotEmpty().WithMessage("The airport name shouldn't be empty");
            RuleFor(a => a.Country)
                .Matches("^[a-zA-Z]+$").WithMessage("Airport country should have just letters")
                .NotEmpty().WithMessage("The airport country shouldn't be empty");
            RuleFor(a => a.City)
                .Matches("^[a-zA-Z]+$").WithMessage("Airport country should have just letters")
                .NotEmpty().WithMessage("The airport country shouldn't be empty");
        }
    }
}
