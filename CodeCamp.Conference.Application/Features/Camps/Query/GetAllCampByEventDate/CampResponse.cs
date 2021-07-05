using CodeCamp.Conference.Application.Response;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate
{
    public class CampResponse:BaseResponse
    {
        public CampDto[] data { get; set; }
        public CampResponse()
        {

        }
    }
}
