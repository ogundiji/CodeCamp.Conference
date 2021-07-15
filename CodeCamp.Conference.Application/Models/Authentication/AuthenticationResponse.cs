using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Models.Authentication
{
    public class AuthenticationResponse:BaseResponse
    {
        public string Token { get; set; }

        public AuthenticationResponse():base()
        {

        }
    }
}
