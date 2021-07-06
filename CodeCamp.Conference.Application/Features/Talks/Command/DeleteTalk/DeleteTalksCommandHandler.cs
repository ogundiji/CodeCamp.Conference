using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Command.DeleteTalk
{
    public class DeleteTalksCommandHandler : IRequestHandler<DeleteTalkCommand, DeleteTalkCommandResponse>
    {
        private readonly ITalkRepository talkRepository;
        public DeleteTalksCommandHandler(ITalkRepository talkRepository)
        {
            this.talkRepository = talkRepository;
        }

        public async Task<DeleteTalkCommandResponse> Handle(DeleteTalkCommand request, CancellationToken cancellationToken)
        {
            var talkToDelete = await talkRepository.GetByIdAsync(request.TalkId);
            var talkDeleteResponse = new DeleteTalkCommandResponse();

            if (talkToDelete == null)
            {
                talkDeleteResponse.Message = "Record Not Found";
                talkDeleteResponse.Success = false;
                throw new NotFoundException(nameof(Talk), request.TalkId);
            }

            if (talkDeleteResponse.Success)
            {
                talkDeleteResponse.Message = "Successfully Deleted";
                await talkRepository.DeleteAsync(talkToDelete);
            }

            return talkDeleteResponse;
        }
    }
}
