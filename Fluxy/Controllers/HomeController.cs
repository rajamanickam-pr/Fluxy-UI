using Fluxy.Infrastructure;
using System.Web.Mvc;
using AutoMapper;
using Fluxy.Services.Banners;
using Fluxy.Services.Logging;
using Fluxy.Services.Video;
using Fluxy.ViewModels.Video;
using System.Collections.Generic;
using PagedList;
using System.Linq;
using Fluxy.ViewModels.Home;

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

        public ActionResult Index(int? recentPage, int? popularPage)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = recentPage ?? 1;
            var recentlyAdded = _videoAttributesService.GetAll().OrderByDescending(i => i.CreatedDate).Take(10);
            var recentlyAddedVM = _mapper.Map<List<VideoAttributesViewModel>>(recentlyAdded).ToPagedList(pageIndex, pageSize);

            int popularPageIndex = 1;
            popularPageIndex = popularPage ?? 1;
            var popularVideos = _videoAttributesService.GetAll().OrderByDescending(i => i.ViewCount).Take(10);
            var popularVideosVM = _mapper.Map<List<VideoAttributesViewModel>>(popularVideos).ToPagedList(popularPageIndex, pageSize);


            HomeViewModel homeViewModel = new HomeViewModel
            {
                RecentVideos = recentlyAddedVM,
                PopularVideos = popularVideosVM
            };

            return Request.IsAjaxRequest()
                ? recentPage.HasValue ? (ActionResult)PartialView("_UnobtrusivePartial", homeViewModel.RecentVideos) :
                 (ActionResult)PartialView("_UnobtrusivePartial", homeViewModel.PopularVideos)
                : View(homeViewModel);
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