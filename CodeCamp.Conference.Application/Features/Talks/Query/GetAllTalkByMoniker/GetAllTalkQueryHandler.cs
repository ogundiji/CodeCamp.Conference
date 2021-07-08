using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetAllTalkByMoniker
{
    public class GetAllTalkQueryHandler : IRequestHandler<GetAllTalkQuery, TalkResponse>
    {
        private readonly IMapper mapper;
        private readonly ITalkRepository talkRepository;
        public GetAllTalkQueryHandler(IMapper mapper, ITalkRepository talkRepository)
        {
            this.mapper = mapper;
            this.talkRepository = talkRepository;
        }
        public async Task<TalkResponse> Handle(GetAllTalkQuery request, CancellationToken cancellationToken)
        {
            var response = new TalkResponse();
            var allTalkRecord = await talkRepository
                .GetTalksByMonikerAsync(request.moniker, request.includeSpeakers);


            if (response.Success)
            {
                response.statusCode = 200;
                response.data = mapper.Map<TalkDto[]>(allTalkRecord);
                response.Message = "successfully retrieved record";
            }
           

            return response;
        }
    }
}
