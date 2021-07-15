using CodeCamp.Conference.Application.Contracts.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Command.CreateTalk
{
    public class CreateTalksCommandValidator:AbstractValidator<CreateTalksCommand>
    {
        private readonly ITalkRepository talkRepository;
        public CreateTalksCommandValidator(ITalkRepository talkRepository)
        {
            this.talkRepository = talkRepository;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(x => x.Abstract)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("{propertyName} is required")
                .GreaterThan(1);

            RuleFor(x => x.SpeakerId)
                .NotEmpty().WithMessage("{propertyName} is required")
                .NotNull();

            RuleFor(e => e)
             .MustAsync(CheckTalkTitleExist)
             .WithMessage("these title already exists.");
            
        }
        private async Task<bool> CheckTalkTitleExist(CreateTalksCommand e, CancellationToken token)
        {
            return !(await talkRepository.VerifyTalkTitle(e.Title));
        }
    }


}
