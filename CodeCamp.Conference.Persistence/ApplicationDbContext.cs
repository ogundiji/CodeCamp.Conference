using CodeCamp.Conference.Application.Contracts;
using CodeCamp.Conference.Domain.Common;
using CodeCamp.Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Persistence
{
    public class ApplicationDbContext:DbContext
    {
        private readonly ILoggedInUserService loggedInUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService loggedInUserService) :base(options)
        {
            this.loggedInUserService = loggedInUserService;
        }

        public DbSet<Camp> Camps { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Talk> Talks { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.CreatedBy = loggedInUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = loggedInUserService.UserId;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
