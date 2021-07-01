using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetSingleCamp
{
    public class GetSingleCampQuery:IRequest<CampDto>
    {
        public string moniker { get; set; }
        public bool includeTalks { get; set; }
    }
}
