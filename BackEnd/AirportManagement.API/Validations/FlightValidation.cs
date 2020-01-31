using AirportManagement.Data;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class FlightValidation : AbstractValidator<Flight>
    {
        public FlightValidation()
        {
            RuleFor(f => f.FlightNumber)
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Flight number should contain only alphanumeric characters")
                .NotEmpty().WithMessage("Flight number shouldn't be empty");
            RuleFor(f => f.Aircraft)
                .NotEmpty().WithMessage("Aircraft shouldn't be empty");
            RuleFor(f => f.Destination)
                .NotEmpty().WithMessage("Destination shouldn't be empty");
            RuleFor(f => f.EstimationTime)
                .NotEmpty().WithMessage("EstimationTime shouldn't be empty");
            RuleFor(f => f.DepartureTime)
                .NotEmpty().WithMessage("DepartureTime shouldn't be empty");
            RuleFor(f => f.ArrivalTime)
                .NotEmpty().WithMessage("ArrivalTime shouldn't be empty");
            RuleFor(f => f.Status)
                .NotEmpty().WithMessage("Status shouldn't be empty");
            RuleFor(f => f.Terminal)
                .NotEmpty().WithMessage("Terminal shouldn't be empty");
            RuleFor(f => f.Gate)
                .NotEmpty().WithMessage("Gate shouldn't be empty");
            RuleFor(f => f.Airline)
                .Matches("^[a-zA-Z]+$").WithMessage("Airline should have just letters")
                .NotEmpty().WithMessage("Airline shouldn't be empty");
        }
    }
}