using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetTalkById
{
    public class GetTalkQueryHandler : IRequestHandler<GetTalkQuery, TalkResponse>
    {
        private readonly ITalkRepository talkRepository;
        private readonly IMapper mapper;
        public GetTalkQueryHandler(ITalkRepository talkRepository, IMapper mapper)
        {
            this.talkRepository = talkRepository;
            this.mapper = mapper;
        }
        public async Task<TalkResponse> Handle(GetTalkQuery request, CancellationToken cancellationToken)
        {
            var response = new TalkResponse();
            var talkRecord = await talkRepository.GetByIdAsync(request.talkId);

            if (talkRecord == null)
            {
                response.Success = false;
                throw new NotFoundException(nameof(Talk), request.talkId);
            }

            if (response.Success)
            {
                response.data = mapper.Map<TalkDto>(talkRecord);
            }

            return response;
        }
    }
}
