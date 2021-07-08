using CodeCamp.Conference.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetSingleCamp
{
    public class CampVm
    {
        public Guid CampId { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; }
        public int Length { get; set; }
        public string Venue { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Talk> Talks { get; set; }
    }
}
