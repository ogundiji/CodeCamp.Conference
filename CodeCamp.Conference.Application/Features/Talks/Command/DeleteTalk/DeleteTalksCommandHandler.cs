using CodeCamp.Conference.Application.Contracts;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace CodeCamp.Conference.Application.Features.Talks.Command.DeleteTalk
{
    public class DeleteTalksCommandHandler : IRequestHandler<DeleteTalkCommand, DeleteTalkCommandResponse>
    {
        private readonly ITalkRepository talkRepository;
        private readonly ILoggedInUserService LoggedInUserService;
        public DeleteTalksCommandHandler(ITalkRepository talkRepository, ILoggedInUserService LoggedInUserService)
        {
            this.talkRepository = talkRepository;
            this.LoggedInUserService = LoggedInUserService;
        }

        public async Task<DeleteTalkCommandResponse> Handle(DeleteTalkCommand request, CancellationToken cancellationToken)
        {
            var talkToDelete = await talkRepository.GetByIdAsync(request.TalkId);
            var talkDeleteResponse = new DeleteTalkCommandResponse();

            if (talkToDelete == null)
            {
                talkDeleteResponse.statusCode = 404;
                talkDeleteResponse.Message = "Record Not Found";
                talkDeleteResponse.Success = false;
                throw new NotFoundException(nameof(Talk), request.TalkId);
            }

            if (talkDeleteResponse.Success)
            {
                talkToDelete.isDeleted = true;
                talkToDelete.DeletedBy = LoggedInUserService.UserId;
                talkToDelete.dateDeleted = DateTime.Now;
                talkDeleteResponse.statusCode = 200;
                talkDeleteResponse.Message = "Successfully Deleted";
                await talkRepository.DeleteAsync(talkToDelete);
            }

            return talkDeleteResponse;
        }
    }
}
