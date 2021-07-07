using CodeCamp.Conference.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeCamp.Conference.Identity
{
    public class CodeCampIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public CodeCampIdentityDbContext(DbContextOptions<CodeCampIdentityDbContext> options):base(options)
        {
        }
    }
}
