using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Persistence.Repository
{
    public class CampRepository: BaseRepository<Camp>,ICampRepository
    {
        private readonly ApplicationDbContext context;
        public CampRepository(ApplicationDbContext context) :base(context)
        {
            this.context = context;
        }

        public async Task<bool> CheckIfMonikerExist(string moniker)
        {
            return await context.Camps.AnyAsync(x => x.Moniker.ToUpper() == moniker.ToUpper());
        }

        public async Task<Camp[]> GetAllCampsAsync(bool includeTalks = false)
        {
            IQueryable<Camp> query = context.Camps;

            if (includeTalks)
            {
                query = query
                  .Include(c => c.Talks.Select(t => t.Speaker));
            }

            // Order It
            query = query.OrderByDescending(c => c.EventDate);

            return await query.ToArrayAsync();
        }

        public async Task<Camp[]> GetAllCampsByEventDate(DateTime dateTime, bool includeTalks = false)
        {
            IQueryable<Camp> query = context.Camps;
                

            if (includeTalks)
            {
                query = query
                  .Include(c => c.Talks.Select(t => t.Speaker));
            }

            // Order It
            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate == dateTime);

            return await query.ToArrayAsync();
        }

        public async Task<Camp> GetCampAsync(string moniker, bool includeTalks = false)
        {
            IQueryable<Camp> query = context.Camps;

            if (includeTalks)
            {
                query = query.Include(c => c.Talks.Select(t => t.Speaker));
            }

            // Query It
            query = query.Where(c => c.Moniker == moniker);

            return await query.FirstOrDefaultAsync();
        }
    }
}
