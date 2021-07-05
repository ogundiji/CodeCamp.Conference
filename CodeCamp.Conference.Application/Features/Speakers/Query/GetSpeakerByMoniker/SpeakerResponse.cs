using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerByMoniker
{
    public class SpeakerResponse:BaseResponse
    {
        public SpeakerDto[] data { get; set; }
        public SpeakerResponse():base()
        {

        }
    }
}
