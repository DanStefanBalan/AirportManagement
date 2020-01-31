using AirportManagement.Data;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class GateValidation : AbstractValidator<Gate>
    {
        public GateValidation()
        {
            RuleFor(g => g.GateNumber)
                .NotEmpty().WithMessage("The gate number shouldn't be empty")
                .GreaterThan(0).WithMessage("The gate number should be greater than 0");

        }

    }
}