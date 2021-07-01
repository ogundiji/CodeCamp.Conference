using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate
{
    public class GetAllCampByDateQueryHandler : IRequestHandler<GetAllCampByDateQuery, CampDto[]>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetAllCampByDateQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }

        public async Task<CampDto[]> Handle(GetAllCampByDateQuery request, CancellationToken cancellationToken)
        {
            var allCampRecordByDate = await campRepository
                .GetAllCampsByEventDate(request.dateTime, request.includeSpeakers);

            return mapper.Map<CampDto[]>(allCampRecordByDate);
        }
    }
}
