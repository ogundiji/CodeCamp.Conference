using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetAllSpeaker
{
    public class GetAllSpeakerQueryHandler : IRequestHandler<GetAllSpeakerQuery, SpeakerResponse>
    {
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public GetAllSpeakerQueryHandler(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            this.speakerRepository = speakerRepository;
            this.mapper = mapper;
        }
        public async Task<SpeakerResponse> Handle(GetAllSpeakerQuery request, CancellationToken cancellationToken)
        {
            var allSpeakerRecord = await speakerRepository.ListAllAsync();
            var response = new SpeakerResponse();

            if (response.Success)
            {
                response.data= mapper.Map<SpeakerDto[]>(allSpeakerRecord);
            }

            return response;
        }
    }
}
