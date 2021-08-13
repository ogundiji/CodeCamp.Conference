using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CodeCamp.Conference.Identity.Models
{
    public class Role:IdentityRole<int>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleMenu> RoleMenus { get; set; }

    }
}
