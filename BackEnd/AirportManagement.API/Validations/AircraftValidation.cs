using AirportManagement.API.Models;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class AircraftValidation : AbstractValidator<AircraftModel>
    {
        public AircraftValidation()
        {
            RuleFor(a => a.AircraftNumber)
                .NotEmpty();
            RuleFor(a => a.CountryOfRegistration)
                .NotEmpty();
            RuleFor(a => a.NumberOfPilots)
                .NotEmpty();
            RuleFor(a => a.Manufacturer)
                .NotEmpty();
            RuleFor(a => a.Model)
                .NotEmpty();
            RuleFor(a => a.NumberOfSeats)
                .NotEmpty();
            RuleFor(a => a.NumberOfFlightAttendants)
                .NotEmpty();
        }
    }
}