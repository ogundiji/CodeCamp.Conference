using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCamp.Conference.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public  DateTime CreateDate { get;set;}
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
