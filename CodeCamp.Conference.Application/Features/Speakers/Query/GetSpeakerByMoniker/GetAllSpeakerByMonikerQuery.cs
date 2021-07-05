using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerByMoniker
{
    public class GetAllSpeakerByMonikerQuery:IRequest<SpeakerResponse>
    {
        public string Moniker { get; set; }
    }
}
