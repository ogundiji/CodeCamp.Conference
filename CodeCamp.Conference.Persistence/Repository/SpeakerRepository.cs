using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Persistence.Repository
{
    public class SpeakerRepository : BaseRepository<Speaker>, ISpeakerRepository
    {
        private readonly ApplicationDbContext context;
        public SpeakerRepository(ApplicationDbContext context) :base(context)
        {
            this.context = context;
        }
        public async Task<bool> CheckIfGithubExist(string Github)
        {
            return !(await context.Speakers.AnyAsync(x => x.GitHub.ToUpper() == Github.ToUpper()));
        }

        public async Task DisableSpeaker(Guid id)
        {
            var speakerToDisable = await context.Speakers.FirstOrDefaultAsync(x => x.SpeakerId == id && !x.isDeleted);

            if (speakerToDisable == null)
                throw new NotFoundException(nameof(Speaker), id);


            speakerToDisable.isDeleted = true;
        }

        public async Task EnableSpeaker(Guid id)
        {
            var speakerToDisable = await context.Speakers.FirstOrDefaultAsync(x => x.SpeakerId == id && !x.isDeleted);

            if (speakerToDisable == null)
                throw new NotFoundException(nameof(Camp), id);

            speakerToDisable.isDeleted = false;
        }

        public async Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker)
        {
            IQueryable<Speaker> query = context.Talks
             .Where(t => t.Camp.Moniker == moniker && !t.isDeleted)
             .Select(t => t.Speaker)
             .Where(s => s != null)
             .OrderBy(s => s.LastName)
             .Distinct();

            return await query.ToArrayAsync();
        }
    }
}
