using System;
using System.Collections.Generic;
using System.Text;
using CodeCamp.Conference.Domain.Common;

namespace CodeCamp.Conference.Domain.Entities
{
    public class Speaker:AuditableEntity
    {
        public Guid SpeakerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Company { get; set; }
        public string CompanyUrl { get; set; }
        public string BlogUrl { get; set; }
        public string Twitter { get; set; }
        public string GitHub { get; set; }
    }
}
