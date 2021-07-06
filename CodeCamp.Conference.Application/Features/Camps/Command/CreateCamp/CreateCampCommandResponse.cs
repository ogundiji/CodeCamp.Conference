using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.CreateCamp
{
    public class CreateCampCommandResponse:BaseResponse
    {
        public List<string> ValidationErrors { get; set; }
        public CreateCampCommandResponse():base()
        {

        }
    }
}
