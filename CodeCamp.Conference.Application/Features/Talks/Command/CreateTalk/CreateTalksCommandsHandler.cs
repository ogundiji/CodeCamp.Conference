using AutoMapper;
using CodeCamp.Conference.Application.Contracts;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Command.CreateTalk
{
    public class CreateTalksCommandsHandler : IRequestHandler<CreateTalksCommand, CreateTalksCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ITalkRepository talkRepository;
        private readonly ISpeakerRepository speakerRepository;
        private readonly ILoggedInUserService loggedInUserService;
        public CreateTalksCommandsHandler(IMapper mapper, ILoggedInUserService loggedInUserService, ITalkRepository talkRepository,ISpeakerRepository speakerRepository)
        {
            this.mapper = mapper;
            this.talkRepository = talkRepository;
            this.speakerRepository = speakerRepository;
            this.loggedInUserService = loggedInUserService;
        }

        public async Task<CreateTalksCommandResponse> Handle(CreateTalksCommand request, CancellationToken cancellationToken)
        {
            var talkResponse = new CreateTalksCommandResponse();
            var validation = new CreateTalksCommandValidator(talkRepository);
            var validationResult = await validation.ValidateAsync(request);

            var speaker = await speakerRepository.GetByIdAsync(request.SpeakerId);
           
            if (speaker == null)
            {
                talkResponse.statusCode = 404;
                talkResponse.Success = false;
                talkResponse.Message = "record not found";
                throw new NotFoundException(nameof(Speakers), request.SpeakerId);
            }

            if (validationResult.Errors.Count > 0)
            {
                talkResponse.Success = false;
                talkResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    talkResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (talkResponse.Success)
            {
                talkResponse.statusCode = 200;
                talkResponse.Message = "Created Successfully";
                request.speaker = speaker;
                var talk = mapper.Map<Talk>(request);
                talk.CreateDate = DateTime.Now;
                talk.CreatedBy = loggedInUserService.UserId;
                await talkRepository.AddAsync(talk);
            }

            return talkResponse;
        }
    }
}
