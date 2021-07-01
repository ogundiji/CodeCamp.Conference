using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetSingleTalkByMoniker
{
    public class GetSingleTalkQueryHandler : IRequestHandler<GetSingleTalkQuery, TalkDto>
    {
        private readonly ITalkRepository talkRepository;
        private readonly IMapper mapper;
        public GetSingleTalkQueryHandler(ITalkRepository talkRepository, IMapper mapper)
        {
            this.talkRepository = talkRepository;
            this.mapper = mapper;
        }
        public async Task<TalkDto> Handle(GetSingleTalkQuery request, CancellationToken cancellationToken)
        {
            var talkRecord = await talkRepository
                .GetSingleTalkByMonikerAsync(request.moniker, request.TalkId, request.includeSpeaker);

            return mapper.Map<TalkDto>(talkRecord);
        }
    }
}
