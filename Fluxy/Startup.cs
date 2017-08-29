using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Fluxy.Data;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(Fluxy.Startup))]
namespace Fluxy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            FluxyContext context = new FluxyContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Users"))
            {
                var role = new IdentityRole();
                role.Name = "Users";
                roleManager.Create(role);

            }
            var adminUser = UserManager.FindByName("Rajadityan");
            if (adminUser == null)
            {
                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Rajadityan";
                user.Email = "rajamanickam.rp@gmail.com";
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
