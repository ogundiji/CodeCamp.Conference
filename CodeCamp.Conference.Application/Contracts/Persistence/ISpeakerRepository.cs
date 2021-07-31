using CodeCamp.Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Contracts.Persistence
{
    public interface ISpeakerRepository:IAsyncRepository<Speaker>
    {
        Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker);
        Task<bool> CheckIfGithubExist(string Github);
        Task<Speaker> GetActiveSpeaker(Guid id);
        
    }
}
