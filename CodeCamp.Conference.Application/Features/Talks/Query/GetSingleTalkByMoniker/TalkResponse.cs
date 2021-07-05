using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetSingleTalkByMoniker
{
    public class TalkResponse:BaseResponse
    {
        public TalkDto data { get; set; }
        public TalkResponse():base()
        {
        }
    }
}
