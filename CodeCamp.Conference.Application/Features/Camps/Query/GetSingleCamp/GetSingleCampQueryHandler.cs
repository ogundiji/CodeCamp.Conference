using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetSingleCamp
{
    public class GetSingleCampQueryHandler : IRequestHandler<GetSingleCampQuery, CampDto>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetSingleCampQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }
        public async Task<CampDto> Handle(GetSingleCampQuery request, CancellationToken cancellationToken)
        {
            var campRecord = await campRepository.GetCampAsync(request.moniker, request.includeTalks);

            return mapper.Map<CampDto>(campRecord);
        }
    }
}
