using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker
{
    public class CreateSpeakersCommandHandler : IRequestHandler<CreateSpeakerCommand, CreateSpeakerCommandResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        public CreateSpeakersCommandHandler(ISpeakerRepository speakerRepository)
        {
            this.speakerRepository = speakerRepository;
        }
        public async Task<CreateSpeakerCommandResponse> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speakerResponse = new CreateSpeakerCommandResponse();
            var validation = new CreateSpeakerCommandValidator(speakerRepository);
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                speakerResponse.Success = false;
                speakerResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    speakerResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (speakerResponse.Success)
            {
                var speaker = new Speaker() 
                { 
                  FirstName=request.FirstName,
                  LastName=request.LastName,
                  MiddleName=request.MiddleName,
                  Company=request.Company,
                  CompanyUrl=request.CompanyUrl,
                  GitHub=request.GitHub
                };
                
                var lol= await speakerRepository.AddAsync(speaker);
                
            }
            return speakerResponse;
        }
    }
}
