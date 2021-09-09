using CodeCamp.Conference.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Identity.Seed
{
    public static class DefaultUser
    {
        public static async Task SeedAsync(UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            await CreateRoles(roleManager);
            var applicationUser = new User
            {
                Firstname = "John",
                Lastname = "Smith",
                UserName = "johnsmith",
                Email = "john@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Tunabo1234$");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        private static async Task CreateRoles(RoleManager<Role> _roleManager)
        {
            bool x = await _roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                var role = new Role();
                role.Name = "Admin";
                role.IsActive = true;
                role.CreatedOn = DateTime.Now;
                await _roleManager.CreateAsync(role);
            }

            bool y = await _roleManager.RoleExistsAsync("Author");
            if (!y)
            {
                var role = new Role();
                role.Name = "Author";
                role.IsActive = true;
                role.CreatedOn = DateTime.Now;
                await _roleManager.CreateAsync(role);
            }

            bool z = await _roleManager.RoleExistsAsync("Super Admin");
            if (!z)
            {
                var role = new Role();
                role.Name = "Super Admin";
                role.IsActive = true;
                role.CreatedOn = DateTime.Now;
                await _roleManager.CreateAsync(role);
            }


        }
    }
}
