using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.DeleteSpeaker
{
    public class DeleteSpeakerCommand:IRequest
    {
        public Guid SpeakerId { get; set; }
    }
}
