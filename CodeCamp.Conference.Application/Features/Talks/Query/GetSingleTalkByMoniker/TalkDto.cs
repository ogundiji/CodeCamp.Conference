using CodeCamp.Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Query.GetSingleTalkByMoniker
{
    public class TalkDto
    {
        public Guid TalkId { get; set; }
        public Camp Camp { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public Speaker Speaker { get; set; }
    }
}
