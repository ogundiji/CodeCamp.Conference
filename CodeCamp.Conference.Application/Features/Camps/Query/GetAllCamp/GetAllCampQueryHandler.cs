using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCamp
{
    public class GetAllCampQueryHandler : IRequestHandler<GetAllCampQuery, CampDto[]>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetAllCampQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }

        public async Task<CampDto[]> Handle(GetAllCampQuery request, CancellationToken cancellationToken)
        {
            var allCampRecord = await campRepository.GetAllCampsAsync(request.includeSpeakers);

            return mapper.Map<CampDto[]>(allCampRecord);
        }
    }
}
