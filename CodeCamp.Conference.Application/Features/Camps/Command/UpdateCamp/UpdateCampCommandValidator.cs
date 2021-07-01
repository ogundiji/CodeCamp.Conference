using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.UpdateCamp
{
    public class UpdateCampCommandValidator:AbstractValidator<UpdateCampCommand>
    {
        public UpdateCampCommandValidator()
        {
            RuleFor(p => p.Moniker)
                 .NotEmpty().WithMessage("{propertyName} is required")
                 .NotNull();

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{propertyName} is required")
               .NotNull();

            RuleFor(p => p.EventDate)
                .Must(BeAValidDate)
                .WithMessage("{propertyName} is required");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
