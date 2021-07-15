using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;

namespace CodeCamp.Conference.Application.Features.Talks.Command.CreateTalk
{
    public class CreateTalksCommand:IRequest<CreateTalksCommandResponse>
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public Guid SpeakerId { get; set; }
    }
}
