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
    public class GetAllSpeakerQueryHandler : IRequestHandler<GetAllSpeakerQuery, SpeakerDto[]>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public GetAllSpeakerQueryHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
        }
        public async Task<SpeakerDto[]> Handle(GetAllSpeakerQuery request, CancellationToken cancellationToken)
        {
            var allSpeakerRecord = await speakerRepository.GetSpeakersByMonikerAsync(request.Moniker);

            return mapper.Map<SpeakerDto[]>(allSpeakerRecord);
        }
    }
}
