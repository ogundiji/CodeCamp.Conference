using CodeCamp.Conference.Application.Response;
using System.Collections.Generic;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker
{
    public class CreateSpeakerCommandResponse:BaseResponse
    {
        public List<string> ValidationErrors { get; set; }
        public CreateSpeakerCommandResponse():base()
        {

        }
    }
}
