using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Conference.Identity.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public string MenuUrl { get; set; }
        public int MenuGroupId { get; set; }
        public string ImgClass { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public MenuGroup MenuGroup { get; set; }
        public ICollection<RoleMenu> RoleMenus { get; set; }

    }
}
