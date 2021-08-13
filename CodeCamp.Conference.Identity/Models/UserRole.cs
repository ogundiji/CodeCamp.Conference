using Microsoft.AspNetCore.Identity;
using System;

namespace CodeCamp.Conference.Identity.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
      
    }
}
