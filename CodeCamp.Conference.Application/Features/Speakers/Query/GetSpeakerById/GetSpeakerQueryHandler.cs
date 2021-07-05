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

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerById
{
    public class GetSpeakerQueryHandler : IRequestHandler<GetSpeakerQuery, SpeakerResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public GetSpeakerQueryHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
        }
        public async Task<SpeakerResponse> Handle(GetSpeakerQuery request, CancellationToken cancellationToken)
        {
            var response = new SpeakerResponse();
            var speakerRecord = await speakerRepository.GetByIdAsync(request.SpeakerId);

            if(speakerRecord==null)
            {
                response.data = null;
                response.Success = false;

                throw new NotFoundException(nameof(Speaker), request.SpeakerId);
            }

            response.data = mapper.Map<SpeakerDto>(speakerRecord);


            return response;

        }
    }
}
