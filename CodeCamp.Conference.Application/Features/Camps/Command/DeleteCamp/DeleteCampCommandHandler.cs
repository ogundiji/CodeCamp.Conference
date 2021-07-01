using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.DeleteCamp
{
    public class DeleteCampCommandHandler : IRequestHandler<DeleteCampCommand, DeleteCampResponse>
    {
        private readonly ICampRepository campRepository;
        public DeleteCampCommandHandler(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
        }
        public async Task<DeleteCampResponse> Handle(DeleteCampCommand request, CancellationToken cancellationToken)
        {
            var campToDelete = await campRepository.GetByIdAsync(request.campId);
            var deleteCampResponse = new DeleteCampResponse();

            if (campToDelete == null)
            {
                deleteCampResponse.Success = false;
                throw new NotFoundException(nameof(Camp), request.campId);
            }

            if (deleteCampResponse.Success)
            {
                await campRepository.DeleteAsync(campToDelete);
            }

            return deleteCampResponse;
        }
    }
}
