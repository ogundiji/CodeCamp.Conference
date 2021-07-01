using AutoMapper;
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

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.DeleteSpeaker
{
    public class DeleteSpeakersCommandHandler : IRequestHandler<DeleteSpeakerCommand,DeleteSpeakerResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public DeleteSpeakersCommandHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
        }
       

        public async Task<DeleteSpeakerResponse> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            var speakerToDelete = await speakerRepository.GetByIdAsync(request.SpeakerId);
            var speakerResponse = new DeleteSpeakerResponse();

            if (speakerToDelete == null)
            {
                speakerResponse.Success = false;
                throw new NotFoundException(nameof(Speaker), request.SpeakerId);
            }

            if (speakerResponse.Success)
            {
                await speakerRepository.DeleteAsync(speakerToDelete);
            }

            return speakerResponse;
        }
    }
}
