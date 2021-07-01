using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetSingleTalkByMoniker
{
    public class GetSingleTalkQuery:IRequest<TalkDto>
    {
        public Guid TalkId { get; set; }
        public string moniker { get; set; }
        public bool includeSpeaker { get; set; }
    }
}
