using MediatR;
using System;

namespace CodeCamp.Conference.Application.Features.Talks.Command.DeleteTalk
{
    public class DeleteTalkCommand:IRequest<DeleteTalkCommandResponse>
    {
        public Guid TalkId { get; set; }
    }
}
