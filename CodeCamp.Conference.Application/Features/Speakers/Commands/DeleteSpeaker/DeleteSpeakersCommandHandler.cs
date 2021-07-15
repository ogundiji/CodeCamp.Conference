using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using CodeCamp.Conference.Application.Contracts;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.DeleteSpeaker
{
    public class DeleteSpeakersCommandHandler : IRequestHandler<DeleteSpeakerCommand,DeleteSpeakerResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        private readonly ILoggedInUserService loggedInUserService;
        public DeleteSpeakersCommandHandler(ISpeakerRepository speakerRepository, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
            this.loggedInUserService = loggedInUserService;
        }
       

        public async Task<DeleteSpeakerResponse> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speakerToDelete = await speakerRepository.GetByIdAsync(request.SpeakerId);
            var speakerResponse = new DeleteSpeakerResponse();

            if (speakerToDelete == null)
            {
                speakerResponse.statusCode = 404;
                speakerResponse.Success = false;
                speakerResponse.Message = "record not found";
                throw new NotFoundException(nameof(Speaker), request.SpeakerId);
            }

            if (speakerResponse.Success)
            {
                speakerToDelete.isDeleted = true;
                speakerToDelete.dateDeleted = DateTime.Now;
                speakerToDelete.DeletedBy = loggedInUserService.UserId;
                speakerResponse.statusCode = 200;
                speakerResponse.Message = "Successfully Deleted Record";
                
                await speakerRepository.UpdateAsync(speakerToDelete);
            }

            return speakerResponse;
        }
    }
}
