using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetSingleCamp
{
    public class GetSingleCampQueryHandler : IRequestHandler<GetSingleCampQuery, CampResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetSingleCampQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }
        public async Task<CampResponse> Handle(GetSingleCampQuery request, CancellationToken cancellationToken)
        {
            var campRecord = await campRepository.GetCampAsync(request.moniker);
            var response = new CampResponse();

            if (response.Success)
            {
                response.statusCode = 200;
                response.Message = "successfully retrieved record";
                response.data= mapper.Map<CampVm>(campRecord);
            }
            return response;
        }
    }
}
