using Event.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Business.ValidationRules.FluentValidation
{
    public class UserAuthenticationDtoValidator : AbstractValidator<UserAuthenticationDto>
    {
        public UserAuthenticationDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty().MinimumLength(8);
            RuleFor(u => u.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}
