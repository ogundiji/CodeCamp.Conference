using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetCampById
{
    public class GetCampQuery:IRequest<CampResponse>
    {
        public Guid campId { get; set; }
    }
}
