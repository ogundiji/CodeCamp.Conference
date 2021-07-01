using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Command.UpdateTalk
{
    public class UpdateTalkCommandValidator:AbstractValidator<UpdateTalkCommand>
    {
        public UpdateTalkCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{propertyName} is required")
                .NotNull();

            RuleFor(x => x.SpeakerId)
                .NotEmpty().WithMessage("{propertyName} is required")
                .NotNull();

            RuleFor(x => x.TalkId)
                .NotEmpty().WithMessage("{propertyName} is required")
                .NotNull();

        }
    }
}
