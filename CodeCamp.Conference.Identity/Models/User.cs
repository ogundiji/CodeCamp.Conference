using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Identity.Models
{
    public class User:IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
