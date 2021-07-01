using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetAllSpeaker
{
    public class GetAllSpeakerQuery:IRequest<SpeakerDto[]>
    {
    }
}
