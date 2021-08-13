using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Models.Authentication
{
    public class ConfirmedEmailResponse:BaseResponse
    {
        public string userId { get; set; }
        public ConfirmedEmailResponse():base()
        {

        }
    }
}
