using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.UpdateSpeaker
{
    public class UpdateSpeakersCommandValidator:AbstractValidator<UpdateSpeakersCommand>
    {
        public UpdateSpeakersCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.LastName)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull();

            RuleFor(p => p.Company)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull();

            RuleFor(p => p.GitHub)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .NotNull();
        }
    }
}
