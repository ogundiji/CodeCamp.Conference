using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCamp
{
    public class GetAllCampQuery:IRequest<CampDto[]>
    {
        public bool includeSpeakers { get; set; }
    }
}
