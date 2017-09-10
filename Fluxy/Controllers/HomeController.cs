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

namespace Fluxy.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBannerDetailsService _bannerDetailsService;
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;

        public HomeController(ILogService logService, IMapper mapper, IVideoAttributesService videoAttributesService, IBannerDetailsService bannerDetailsService)
            : base(logService, mapper)
        {
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
            _bannerDetailsService = bannerDetailsService;
        }

        public ActionResult Index()
        {
            var recentlyAdded = _videoAttributesService.GetAll().OrderByDescending(i => i.CreatedDate).Take(9);
            var recentlyAddedVM = _mapper.Map<List<VideoAttributesViewModel>>(recentlyAdded);

            var popularVideos = _videoAttributesService.GetAll().OrderByDescending(i => i.ViewCount).Take(9);
            var popularVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(popularVideos);

            var generalVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("People & Blogs")).OrderByDescending(i => i.ViewCount).Take(9);
            var generalVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(generalVideos);

            var infoVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Education")).OrderByDescending(i => i.ViewCount).Take(9);
            var infoVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(infoVideos);

            var entertainmentVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Music")).OrderByDescending(i => i.ViewCount).Take(9);
            var entertainmentVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(entertainmentVideos);

            var bannerList = _mapper.Map<List<BannerDetailsViewModel>>(_bannerDetailsService.GetAll());

            HomeViewModel homeViewModel = new HomeViewModel
            {
                RecentVideos = recentlyAddedVM,
                PopularVideos = popularVideosVM,
                General = generalVideosVM,
                Infotainment = infoVideosVM,
                Entertainment = entertainmentVideosVM,
                Banners= bannerList
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