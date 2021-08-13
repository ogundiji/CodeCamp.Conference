using CodeCamp.Conference.Application.Response;

namespace CodeCamp.Conference.Application.Models.Authentication
{
    public class EmailConfirmationResponse:BaseResponse
    {
        public string token { get; set; }
        public string userId { get; set; }
        public EmailConfirmationResponse():base()
        {
        }
    }
}
