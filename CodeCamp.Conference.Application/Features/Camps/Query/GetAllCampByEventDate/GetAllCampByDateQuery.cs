using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate
{
    public class GetAllCampByDateQuery:IRequest<CampResponse>
    {
        public DateTime dateTime { get; set; }
    }
}
