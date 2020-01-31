using AirportManagement.Data;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class TerminalValidation:AbstractValidator<Terminal>
    {
        public TerminalValidation()
        {
            RuleFor(t => t.Name)
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Name of terminal should contain only alphanumeric characters")
                .NotEmpty().WithMessage("Name of terminal shouldn't be empty");
        }
    }
}