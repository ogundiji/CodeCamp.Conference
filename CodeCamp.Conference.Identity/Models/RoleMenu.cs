using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Identity.Models
{
    public class RoleMenu
    {
        public int Id { get; set; }
        public int menuId { get; set; }
        public int roleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Menu menu { get; set; }
        public Role role { get; set; }
    }
}
