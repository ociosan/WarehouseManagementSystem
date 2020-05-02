using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS.FrontEnd
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser { UserName = "admin", Email = "admin@localhost" };
                var result = userManager.CreateAsync(user, "Rinnegan.01").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrador").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrador"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Empleado").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Empleado"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
