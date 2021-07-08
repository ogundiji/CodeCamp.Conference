using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker
{
    public class CreateSpeakersCommandHandler : IRequestHandler<CreateSpeakerCommand, CreateSpeakerCommandResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public CreateSpeakersCommandHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
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
                speakerResponse.Message = "Successfully created";
                speakerResponse.statusCode = 201;
                var speaker = mapper.Map<Speaker>(request);
                speaker.CreateDate = DateTime.Now;
                speaker.CreatedBy = "yusuf";
                await speakerRepository.AddAsync(speaker);
            }
            return speakerResponse;
        }
    }
}
