using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetAllTalk
{
    public class GetTalkListQueryHandler : IRequestHandler<GetTalkListQuery, TalkVm[]>
    {
        private readonly ITalkRepository talkRepository;
        private readonly IMapper mapper;
        public GetTalkListQueryHandler(ITalkRepository talkRepository, IMapper mapper)
        {
            this.talkRepository = talkRepository;
            this.mapper = mapper;
        }
        public async Task<TalkVm[]> Handle(GetTalkListQuery request, CancellationToken cancellationToken)
        {
            var result =await talkRepository.GetAllTalk();

            return mapper.Map<TalkVm[]>(result);
        }
    }
}
