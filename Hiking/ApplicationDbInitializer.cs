using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking
{
    public static class ApplicationDbInitializer
    {


        public static void SeedUsers(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            IConfiguration _config = config;
            if (userManager.FindByEmailAsync(_config.GetValue<string>("Admin:Email")).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = _config.GetValue<string>("Admin:UserName"),
                    Email = _config.GetValue<string>("Admin:Email"),
                    EmailConfirmed = true
                };

                string password = _config.GetValue<string>("Admin:Password");
                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
