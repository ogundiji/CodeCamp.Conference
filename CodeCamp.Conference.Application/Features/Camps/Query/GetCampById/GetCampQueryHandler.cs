using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetCampById
{
    public class GetCampQueryHandler : IRequestHandler<GetCampQuery,CampResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;
        public GetCampQueryHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.campRepository = campRepository;
        }

        public async Task<CampResponse> Handle(GetCampQuery request, CancellationToken cancellationToken)
        {
            var campRecord = await campRepository.GetByIdAsync(request.campId);
            var response = new CampResponse();

            if (campRecord == null)
            {
                response.statusCode = 404;
                response.Success = false;
                throw new NotFoundException(nameof(Camp), request.campId);
            }

            if (response.Success)
            {
                response.statusCode = 200;
                response.Message = "Successfully retrieved record";
                response.data = mapper.Map<CampByIdDto>(campRecord);
            }

            return response;
        }
    }
}
