﻿using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCamp
{
    public class GetAllCampQueryHandler : IRequestHandler<GetAllCampQuery, CampResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetAllCampQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }

        public async Task<CampResponse> Handle(GetAllCampQuery request, CancellationToken cancellationToken)
        {
            
            var allCampRecord = await campRepository.GetAllCampsAsync();
            var response = new CampResponse();


            if (response.Success)
            {
                response.statusCode = 200;
                response.Message = "Successfully Retrieved record";
                response.data= mapper.Map<CampDto[]>(allCampRecord);
            }
            return response;
        }
    }
}
