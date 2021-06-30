using MediatR;


namespace CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker
{
    public class CreateSpeakerCommand:IRequest<CreateSpeakerCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Company { get; set; }
        public string CompanyUrl { get; set; }
        public string BlogUrl { get; set; }
        public string Twitter { get; set; }
        public string GitHub { get; set; }
    }
}
