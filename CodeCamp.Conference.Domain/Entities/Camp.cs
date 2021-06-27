using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCamp.Conference.Domain.Entities
{
    public class Camp:AuditableEntity
    {
        public Guid CampId { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
        public string Venue { get; set;}
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Talk> Talks { get; set; }
    }
}
