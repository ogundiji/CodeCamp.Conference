using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using CodeCamp.Conference.Application.Contracts;

namespace CodeCamp.Conference.Application.Features.Camps.Command.DeleteCamp
{
    public class DeleteCampCommandHandler : IRequestHandler<DeleteCampCommand, DeleteCampResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly ILoggedInUserService loggedInUserService;
        public DeleteCampCommandHandler(ICampRepository campRepository, ILoggedInUserService loggedInUserService)
        {
            this.campRepository = campRepository;
            this.loggedInUserService = loggedInUserService;
        }
        public async Task<DeleteCampResponse> Handle(DeleteCampCommand request, CancellationToken cancellationToken)
        {
            var campToDelete = await campRepository.GetByIdAsync(request.campId);
            var deleteCampResponse = new DeleteCampResponse();

            if (campToDelete == null)
            {
                deleteCampResponse.statusCode = 404;
                deleteCampResponse.Success = false;
                throw new NotFoundException(nameof(Camp), request.campId);
            }

            if (deleteCampResponse.Success)
            {
                campToDelete.isDeleted = true;
                campToDelete.dateDeleted = DateTime.Now;
                campToDelete.DeletedBy = loggedInUserService.UserId;
                deleteCampResponse.statusCode = 200;
                await campRepository.DeleteAsync(campToDelete);
            }

            return deleteCampResponse;
        }
    }
}
