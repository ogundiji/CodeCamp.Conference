using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCamp.Conference.Domain.Entities
{
    public class Talk:AuditableEntity
    {
        public Guid TalkId { get; set; }
        public Camp Camp { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public Speaker Speaker { get; set; }
    }
}
