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
        public ActionResult Details(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userProfileDetails = _userProfileService.GetSingle(i => i.UserId == userId);
            var userProfile = _mapper.Map<UserMangementViewModel>(userProfileDetails);
            return View(userProfile);
        }
    }   
}