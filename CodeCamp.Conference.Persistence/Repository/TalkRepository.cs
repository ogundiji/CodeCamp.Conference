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
    public class TalkRepository : BaseRepository<Talk>, ITalkRepository
    {
        private readonly ApplicationDbContext context;
        public TalkRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task DisableTalk(Guid id)
        {
            var talkToDisable = await context.Talks.FirstOrDefaultAsync(x => x.TalkId == id && !x.isDeleted);

            if (talkToDisable == null)
                throw new NotFoundException(nameof(Talk), id);


            talkToDisable.isDeleted = true;
        }

        public async Task EnableTalk(Guid id)
        {
            var talkToDisable = await context.Talks.FirstOrDefaultAsync(x => x.TalkId == id && !x.isDeleted);

            if (talkToDisable == null)
                throw new NotFoundException(nameof(Talk), id);

            talkToDisable.isDeleted = false;
        }

        public async Task<Talk> GetSingleTalkByMonikerAsync(string moniker, Guid talkId, bool includeSpeakers = false)
        {
            IQueryable<Talk> query = context.Talks.Where(x=>x.isDeleted==false);

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            // Add Query
            query = query
              .Where(t => t.TalkId == talkId && t.Camp.Moniker == moniker);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Talk[]> GetTalksByMonikerAsync(string moniker, bool includeSpeakers = false)
        {
            IQueryable<Talk> query = context.Talks.Where(x => x.isDeleted == false);

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            // Add Query
            query = query
              .Where(t => t.Camp.Moniker == moniker)
              .OrderByDescending(t => t.Title);

            return await query.ToArrayAsync();
        }


        public async Task<bool> VerifyTalkTitle(string title)
        {
            return await context.Talks.AnyAsync(x => x.Title.ToUpper() == title);
        }
    }
}
