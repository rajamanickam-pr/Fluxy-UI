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
using System.ComponentModel.DataAnnotations;
using System;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : BaseController
    {
        private readonly FluxyContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserProfileService _userProfileService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserManagementController(IUserProfileService userProfileService, ILogService logService, IMapper mapper)
             : base(logService, mapper)
        {
            _context = new FluxyContext();
            _userProfileService = userProfileService;
            _mapper = mapper;
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        // GET: Admin/UserManagement
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

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = _userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    _userManager.AddToRole(user.Id, "Users");
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AddErrors(result);
                    return Json(new { success = false, responseText = "Error occured" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, responseText = "Model is not valid" }, JsonRequestBehavior.AllowGet);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                Danger(error, true);
            }
        }

        public JsonResult Details(string id)
        {
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == id);
            if (userProfileDetails == null)
            {
                userProfileDetails = new UserProfileExtend
                {
                    ApplicationUser = _userManager.Users.FirstOrDefault(i => i.Id == id)
                };
            }
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return Json(userProfile, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual ActionResult ChangeRole(string id, string role)
        {
            var oldUser = _userManager.FindById(id);
            var oldRoleId = oldUser.Roles.SingleOrDefault()?.RoleId;
            var oldRoleName = _roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId)?.Name;

            if (oldRoleName != role)
            {
                _userManager.RemoveFromRole(id, oldRoleName);
                _userManager.AddToRole(id, role);
            }
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}