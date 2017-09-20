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
using Fluxy.Data.ExtentedDTO;
using Fluxy.Core.Constants.UserManagement;

namespace Fluxy.Controllers.Administration
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("usermanagement")]
    public class UserMangementController : BaseController
    {
        private readonly FluxyContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserProfileService _userProfileService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserMangementController(IUserProfileService userProfileService, ILogService logService, IMapper mapper)
             : base(logService, mapper)
        {
            _context = new FluxyContext();
            _userProfileService = userProfileService;
            _mapper = mapper;
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        [HttpGet]
        [Route("", Name = UserManagementRoutes.GetIndex)]
        public ActionResult Index()
        {
            var users = from u in _userManager.Users
                        from ur in u.Roles
                        join r in _roleManager.Roles on ur.RoleId equals r.Id
                        select new UserViewModel
                        {
                            Id = u.Id,
                            Username = u.UserName,
                            Role = r.Name,
                            Email = u.Email
                        };

            return View(UserManagementActions.Index,users);
        }

        [HttpGet, ActionName("Delete")]
        [Route("Delete", Name = UserManagementRoutes.GetDelete)]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(id);
            var logins = user.Logins;
            var rolesForUser = await _userManager.GetRolesAsync(id);

            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.Any())
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        await _userManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }

                await _userManager.DeleteAsync(user);
                transaction.Commit();
            }
            return RedirectToAction(UserManagementActions.Index);
        }

        [HttpGet]
        [Route("Details", Name = UserManagementRoutes.GetDetails)]
        public async Task<ActionResult> Details(string id)
        {
            var userProfileDetails = await _userProfileService.GetSingleAsync(i => i.UserId == id);
            if (userProfileDetails == null)
            {
                userProfileDetails = new UserProfileExtend
                {
                    ApplicationUser = _userManager.Users.FirstOrDefault(i => i.Id == id)
                };
            }
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(UserManagementActions.Details,userProfile);
        }

        [HttpGet]
        [Route("ChangeRole", Name = UserManagementRoutes.GetChangeRole)]
        public async Task<ActionResult> ChangeRole(string id)
        {
            var userProfileDetails = await _userProfileService.GetSingleAsync(i => i.UserId == id);
            if (userProfileDetails == null)
            {
                userProfileDetails = new UserProfileExtend
                {
                    ApplicationUser = _userManager.Users.FirstOrDefault(i => i.Id == id)
                };
            }

            ViewBag.Roles = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            ViewBag.Username = userProfile.ApplicationUser.UserName;
            ViewBag.UserId = userProfile.ApplicationUser.Id;

            return View(UserManagementActions.ChangeRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ChangeRole", Name = UserManagementRoutes.PostChangeRole)]
        public  ActionResult ChangeRole(FormCollection data)
        {
            try
            {
                var id = data["UserId"];
                var role = data["Roles"];

                var oldUser = _userManager.FindById(id);
                var oldRoleId = oldUser.Roles.SingleOrDefault()?.RoleId;
                var oldRoleName = _roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId)?.Name;

                if (oldRoleName != role)
                {
                    _userManager.RemoveFromRole(id, oldRoleName);
                    _userManager.AddToRole(id, role);
                }
                return RedirectToAction(UserManagementActions.Index);
            }
            catch (System.Exception ex)
            {
                Danger(ex.Message);
                return RedirectToAction(UserManagementActions.ChangeRole);
            }
        }
    }
}