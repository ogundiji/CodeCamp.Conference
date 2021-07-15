using MediatR;


namespace CodeCamp.Conference.Application.Features.Talks.Query.GetAllTalk
{
    public class GetTalkListQuery:IRequest<TalkVm[]>
    {
    }
}
