using CodeCamp.Conference.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Contracts.Persistence
{
    public interface ITalkRepository:IAsyncRepository<Talk>
    {
        Task<Talk> GetSingleTalkByMonikerAsync(string moniker, Guid talkId, bool includeSpeakers = false);
        Task<Talk[]> GetAllTalk();
        Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false);
        Task<bool> VerifyTalkTitle(string title);
       
    }
}
