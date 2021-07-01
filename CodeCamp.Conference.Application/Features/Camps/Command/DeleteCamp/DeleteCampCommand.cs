using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.DeleteCamp
{
    public class DeleteCampCommand:IRequest<DeleteCampResponse>
    {
        public Guid campId { get; set; }
    }
}
