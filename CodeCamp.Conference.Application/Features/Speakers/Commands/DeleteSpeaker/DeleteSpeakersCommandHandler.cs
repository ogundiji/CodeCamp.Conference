using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.DeleteSpeaker
{
    public class DeleteSpeakersCommandHandler : IRequestHandler<DeleteSpeakerCommand>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public DeleteSpeakersCommandHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
        }
       

        public async Task<Unit> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            var lol = await speakerRepository.GetByIdAsync(request.SpeakerId);

            if (lol == null)
            {
                throw new NotFoundException(nameof(Speakers), request.SpeakerId);
            }

            await speakerRepository.DeleteAsync(lol);

            return Unit.Value;
        }
    }
}
