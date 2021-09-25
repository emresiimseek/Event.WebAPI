using Event.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Business.ValidationRules.FluentValidation
{
    public class ActivityValidator : AbstractValidator<ActivityDto>
    {
        public ActivityValidator()
        {

            

            RuleFor(u => u.Title).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(u => u.Description).NotNull().MinimumLength(5);
            RuleFor(u => u.EventDate).NotEmpty();
            RuleFor(u => u.ActivityCategories).NotEmpty();
            RuleFor(u => u.UserActivities).NotEmpty();
        }
    }
}
