using Domain.Dtos.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        public AccountDtoValidator()
        {
            RuleFor(x => x.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Invalid password");
            RuleFor(x => x.PasswordConfirmation).Matches(x => x.Password).WithMessage("Passwords don't match");
        }
    }

}
