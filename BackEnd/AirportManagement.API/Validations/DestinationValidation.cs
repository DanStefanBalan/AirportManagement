using System;
using AirportManagement.Data;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class DestinationValidation : AbstractValidator<Destination>
    {
        public DestinationValidation()
        {
            RuleFor(d => d.LocalTime)
                .NotEmpty()
                .Must(BeAValidDate).WithMessage("Invalid date");
            RuleFor(d => d.Weather)
                .NotEmpty().WithMessage("Weather shouldn't be empty");
            RuleFor(d => d.Terminal)
                .NotEmpty();
            RuleFor(d => d.Gate)
                .NotEmpty();
        }

        private bool BeAValidDate(DateTime arg)
        {
            return true;
        }
    }
}