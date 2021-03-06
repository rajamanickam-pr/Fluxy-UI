﻿using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Fluxy.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Fluxy.Startup))]
namespace Fluxy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            FluxyContext context = new FluxyContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Users"))
            {
                var role = new IdentityRole
                {
                    Name = "Users"
                };
                roleManager.Create(role);

            }
            var adminUser = UserManager.FindByName("Rajadityan");
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Rajadityan",
                    Email = "rajamanickam.rp@gmail.com",
                    EmailConfirmed = true
                };
                string userPassword = "Mani2206@";
                var chkUser = UserManager.Create(user, userPassword);
                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
