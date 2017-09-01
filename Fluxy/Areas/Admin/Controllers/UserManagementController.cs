using Fluxy.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Microsoft.AspNet.Identity;
using Fluxy.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Fluxy.ViewModels.User;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : BaseController
    {
        private readonly FluxyContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> UserManager;

        public UserManagementController(ILogService logService, IMapper mapper)
             : base(logService, mapper)
        {
            context = new FluxyContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }

        // GET: Admin/UserManagement
        public ActionResult Index()
        {
            var users = from u in UserManager.Users
                        from ur in u.Roles
                        join r in roleManager.Roles on ur.RoleId equals r.Id
                        select new UserViewModel
                        {
                            Id=u.Id,
                            Username = u.UserName,
                            Role = r.Name,
                            Email=u.Email
                        };

            return View(users);
        }

        [HttpGet]
        public ActionResult FindRole(string id)
        {
            var UserRole = UserManager.Users
                    .Where(u => u.Id == id)
                    .SelectMany(u => u.Roles)
                    .Join(context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r)
                    .ToList();
            return Json(UserRole, JsonRequestBehavior.AllowGet);
        }
    }   
}