using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerByMoniker
{
    public class GetAllSpeakerByMonikerQueryHandler : IRequestHandler<GetAllSpeakerByMonikerQuery, SpeakerResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public GetAllSpeakerByMonikerQueryHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
        }
        public async Task<SpeakerResponse> Handle(GetAllSpeakerByMonikerQuery request, CancellationToken cancellationToken)
        {
            var allSpeakerRecord = await speakerRepository.GetSpeakersByMonikerAsync(request.Moniker);
            var response = new SpeakerResponse();

            response.data = mapper.Map<SpeakerDto[]>(allSpeakerRecord);

            return response;
        }
    }
}
