using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Logging;
using Microsoft.AspNet.Identity;
using Fluxy.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using Fluxy.Areas.Admin.Models;
using Fluxy.Services.Video;

namespace Fluxy.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : BaseController
    {
        private readonly FluxyContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVideoAttributesService _videoAttributesService;

        public AdminHomeController(ILogService logService, IVideoAttributesService videoAttributesService, IMapper mapper)
            : base(logService, mapper)
        {
            _context = new FluxyContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
        }

        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            var totalRegisteredUsers = _userManager.Users.Count();
            var AdultVideosCount = _videoAttributesService.GetList(i => i.IsAdultContent).Count();
            var PublicVideosCount = _videoAttributesService.GetList(i => i.IsPublicVideo).Count();
            var PrivateVideosCount = _videoAttributesService.GetList(i => !i.IsPublicVideo).Count();
            var Admin = new AdminViewModel
            {
                TotalRegisteredUsers = totalRegisteredUsers,
                AdultVideosCount = AdultVideosCount,
                PublicVideosCount = PublicVideosCount,
                PrivateVideosCount= PrivateVideosCount
            };
            return View(Admin);
        }
    }
}