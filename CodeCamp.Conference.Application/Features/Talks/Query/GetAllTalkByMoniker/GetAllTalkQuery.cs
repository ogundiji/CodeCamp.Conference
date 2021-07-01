using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetAllTalkByMoniker
{
    public class GetAllTalkQuery:IRequest<TalkDto[]>
    {
        public string moniker { get; set; }
        public bool includeSpeakers { get; set; }
    }
}
