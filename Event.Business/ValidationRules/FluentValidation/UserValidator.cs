using Event.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.UserName).NotNull().MinimumLength(8).NotEmpty();
            RuleFor(u => u.Password).NotNull().MinimumLength(8);
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.Email).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
