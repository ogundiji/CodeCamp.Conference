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
    public class GetSingleTalkQueryHandler : IRequestHandler<GetSingleTalkQuery,TalkResponse>
    {
        private readonly ITalkRepository talkRepository;
        private readonly IMapper mapper;
        public GetSingleTalkQueryHandler(ITalkRepository talkRepository, IMapper mapper)
        {
            this.talkRepository = talkRepository;
            this.mapper = mapper;
        }
        public async Task<TalkResponse> Handle(GetSingleTalkQuery request, CancellationToken cancellationToken)
        {
            var response = new TalkResponse();
            var talkRecord = await talkRepository
                .GetSingleTalkByMonikerAsync(request.moniker, request.TalkId, request.includeSpeaker);

            if (response.Success)
            {
                response.data = mapper.Map<SingleTalkDto>(talkRecord);
                response.statusCode = 200;
                response.Message = "Successfully retrieved record";
            }
           
            return response;
        }
    }
}
