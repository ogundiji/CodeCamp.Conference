using CodeCamp.Conference.Application.Contracts.Persistence;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker
{
    public class CreateSpeakerCommandValidator:AbstractValidator<CreateSpeakerCommand>
    {
        private readonly ISpeakerRepository speakerRepository;
        public CreateSpeakerCommandValidator(ISpeakerRepository speakerRepository)
        {
            this.speakerRepository = speakerRepository;
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

            RuleFor(e => e)
               .MustAsync(CheckIfSpeakerExist)
               .WithMessage("A Speaker with the same Github profile already exists.");
        }

        private async Task<bool> CheckIfSpeakerExist(CreateSpeakerCommand e, CancellationToken token)
        {
            return await speakerRepository.CheckIfGithubExist(e.GitHub);
        }
    }
}
