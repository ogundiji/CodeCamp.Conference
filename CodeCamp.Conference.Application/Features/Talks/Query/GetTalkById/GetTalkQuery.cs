using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetTalkById
{
    public class GetTalkQuery:IRequest<TalkResponse>
    {
        public Guid talkId { get; set; }
    }
}
