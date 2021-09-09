using CodeCamp.Conference.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeCamp.Conference.Identity
{
    public class CodeCampIdentityDbContext : IdentityDbContext<User,Role,int>
    {
        public CodeCampIdentityDbContext(DbContextOptions<CodeCampIdentityDbContext> options):base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
    }
}
