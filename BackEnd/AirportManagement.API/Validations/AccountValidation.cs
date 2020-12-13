using AirportManagement.API.Models;
using FluentValidation;

namespace AirportManagement.API.Validations
{
    public class AccountValidation : AbstractValidator<AccountModel>
    {
        public AccountValidation()
        {
            RuleFor(a => a.UserName)
                .NotEmpty();
            RuleFor(a => a.Password)
                .NotEmpty();
            RuleFor(a => a.Email)
                .NotEmpty();
        }
    }
}