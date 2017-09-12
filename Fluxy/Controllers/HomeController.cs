using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Banners;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using System.Collections.Generic;
using System.Linq;
using Fluxy.ViewModels.Home;
using Fluxy.ViewModels.Banners;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Fluxy.Services.Users;

namespace Fluxy.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBannerDetailsService _bannerDetailsService;
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly IUserSettingsService _userSettingsService;

        public HomeController(IUserSettingsService userSettingsService, ILogService logService, IMapper mapper, IVideoAttributesService videoAttributesService, IBannerDetailsService bannerDetailsService)
            : base(logService, mapper)
        {
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
            _userSettingsService = userSettingsService;
            _bannerDetailsService = bannerDetailsService;
        }

        public ActionResult Index(string message)
        {
            var isAdultContent = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var userSettings = _userSettingsService.GetSingle(i => i.UserId == userId);
                if (userSettings != null)
                {
                    isAdultContent = userSettings.CanISeeEPContent;
                }
            }

            var recentlyAdded = _videoAttributesService.GetList(i => i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.CreatedDate).Take(9);
            var recentlyAddedVM = _mapper.Map<List<VideoAttributesViewModel>>(recentlyAdded);

            var popularVideos = _videoAttributesService.GetList(i => i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
            var popularVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(popularVideos);

            var generalVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("People & Blogs")
             && i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
            var generalVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(generalVideos);

            var infoVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Education")
             && i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
            var infoVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(infoVideos);

            var entertainmentVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Music")
             && i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
            var entertainmentVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(entertainmentVideos);

            var bannerList = _mapper.Map<List<BannerDetailsViewModel>>(_bannerDetailsService.GetAll());

            if (!string.IsNullOrEmpty(message))
                Warning(message);

            HomeViewModel homeViewModel = new HomeViewModel
            {
                RecentVideos = recentlyAddedVM,
                PopularVideos = popularVideosVM,
                General = generalVideosVM,
                Infotainment = infoVideosVM,
                Entertainment = entertainmentVideosVM,
                Banners = bannerList
            };

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}