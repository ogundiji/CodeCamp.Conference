using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate
{
    public class GetAllCampByDateQueryHandler : IRequestHandler<GetAllCampByDateQuery, CampResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetAllCampByDateQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }

        public async Task<CampResponse> Handle(GetAllCampByDateQuery request, CancellationToken cancellationToken)
        {
            var response = new CampResponse();
            var allCampRecordByDate = await campRepository
                .GetAllCampsByEventDate(request.dateTime);

            if (response.Success)
            {
                response.statusCode = 200;
                response.Message = "Successfully retrieved record";
                response.data = mapper.Map<CampByEventDto[]>(allCampRecordByDate);
            }

            return response ;
        }
    }
}
