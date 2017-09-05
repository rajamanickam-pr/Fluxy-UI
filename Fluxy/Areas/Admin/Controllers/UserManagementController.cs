using Fluxy.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Microsoft.AspNet.Identity;
using Fluxy.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Fluxy.ViewModels.User;
using Fluxy.Services.Users;
using System.Net;
using System.Threading.Tasks;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : BaseController
    {
        private readonly FluxyContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserProfileService _userProfileService;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IMapper _mapper;

        public UserManagementController(IUserProfileService userProfileService, ILogService logService, IMapper mapper)
             : base(logService, mapper)
        {
            context = new FluxyContext();
            _userProfileService = userProfileService;
            _mapper = mapper;
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }

        // GET: Admin/UserManagement
        public async Task<ActionResult> Index()
        {
            var users = from u in UserManager.Users
                        from ur in u.Roles
                        join r in roleManager.Roles on ur.RoleId equals r.Id
                        select new UserViewModel
                        {
                            Id = u.Id,
                            Username = u.UserName,
                            Role = r.Name,
                            Email = u.Email
                        };

            return View(users);
        }

        public JsonResult Details(string id)
        {
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == id);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                var logins = user.Logins;
                var rolesForUser = await UserManager.GetRolesAsync(id);

                using (var transaction = context.Database.BeginTransaction())
                {
                    foreach (var login in logins.ToList())
                    {
                        await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    await UserManager.DeleteAsync(user);
                    transaction.Commit();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public virtual ActionResult ChangeRole(string id, string role)
        {
            var oldUser = UserManager.FindById(id);
            var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
            var oldRoleName = roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;

            if (oldRoleName != role)
            {
                UserManager.RemoveFromRole(id, oldRoleName);
                UserManager.AddToRole(id, role);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}