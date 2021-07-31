using CodeCamp.Conference.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.CreateCamp
{
    public class CreateCampCommandValidator:AbstractValidator<CreateCampCommand>
    {
        private readonly ICampRepository campRepository;
        public CreateCampCommandValidator(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
            RuleFor(p => p.Moniker)
                .NotEmpty().WithMessage("{propertyName} is required")
                .NotNull();

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{propertyName} is required")
               .NotNull();

            RuleFor(p => p.EventDate)
                .Must(BeAValidDate)
                .WithMessage("{propertyName} is required");

            RuleFor(e => e)
                .MustAsync(VerifyMoniker)
                .WithMessage("moniker already exist");


        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }


        private async Task<bool> VerifyMoniker(CreateCampCommand e, CancellationToken token)
        {
            return !(await campRepository.CheckIfMonikerExist(e.Moniker));
        }
    }
}
