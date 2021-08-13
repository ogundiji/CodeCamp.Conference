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
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> menuGroups { get; set; }
        public DbSet<RoleMenu> roleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Role>()
                .HasMany(p => p.RoleMenus)
                .WithOne(p => p.role)
                .HasForeignKey(x => x.roleId);
         
            builder.Entity<Menu>()
                .HasMany(p => p.RoleMenus)
                .WithOne(p => p.menu)
                .HasForeignKey(p => p.menuId);

            builder.Entity<MenuGroup>()
                .HasMany(p => p.Menu)
                .WithOne(p => p.MenuGroup)
                .HasForeignKey(p => p.MenuGroupId);

         

            base.OnModelCreating(builder);

        }
    }
}
