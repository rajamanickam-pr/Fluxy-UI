﻿using Fluxy.Infrastructure;
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
using Microsoft.AspNet.Identity;
using Fluxy.Services.Users;
using Fluxy.ViewModels.Mail;
using Fluxy.Services.Mail;
using Fluxy.Core.Models.Mail;
using System;
using System.Text;
using Fluxy.Core.Constants;
using Fluxy.Core.Constants.HomeController;
using System.Threading.Tasks;
using System.Threading;
using Boilerplate.Web.Mvc;
using Boilerplate.Web.Mvc.Filters;

namespace Fluxy.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBannerDetailsService _bannerDetailsService;
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IContactUsService _contactUsService;

        public HomeController(IContactUsService contactUsService,IUserSettingsService userSettingsService, ILogService logService, IMapper mapper, IVideoAttributesService videoAttributesService, IBannerDetailsService bannerDetailsService)
            : base(logService, mapper)
        {
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
            _userSettingsService = userSettingsService;
            _bannerDetailsService = bannerDetailsService;
            _contactUsService = contactUsService;
        }

        [Route("", Name = HomeControllerRoute.GetIndex)]
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

            var popularVideos = _videoAttributesService.GetList(i => i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);

            var generalVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("People & Blogs")
             && i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);

            var infoVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Education")
             && i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);

            var entertainmentVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Music")
             && i.IsPublicVideo && i.IsAdultContent == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);

            if (!string.IsNullOrEmpty(message))
                Warning(message);

            HomeViewModel homeViewModel = new HomeViewModel
            {
                RecentVideos = _mapper.Map<List<VideoAttributesViewModel>>(recentlyAdded),
                PopularVideos = _mapper.Map<List<VideoAttributesViewModel>>(popularVideos),
                General = _mapper.Map<List<VideoAttributesViewModel>>(generalVideos),
                Infotainment = _mapper.Map<List<VideoAttributesViewModel>>(infoVideos),
                Entertainment = _mapper.Map<List<VideoAttributesViewModel>>(entertainmentVideos),
                Banners = _mapper.Map<List<BannerDetailsViewModel>>(_bannerDetailsService.GetAll())
            };

            return View(HomeControllerAction.Index,homeViewModel);
        }

        [Route("about", Name = HomeControllerRoute.GetAbout)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(HomeControllerAction.About);
        }

        [Route("contact", Name = HomeControllerRoute.GetContact)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(HomeControllerAction.Contact);
        }

        [Route("faq", Name = HomeControllerRoute.GetFAQ)]
        public virtual ActionResult FAQ()
        {
            return View(HomeControllerAction.FAQ);
        }

        [Route("helpdesk", Name = HomeControllerRoute.GetHelpDesk)]
        public virtual ActionResult HelpDesk()
        {
            return View(HomeControllerAction.HelpDesk);
        }

        [HttpPost]
        public virtual ActionResult HelpDesk(ContactUsViewModel contactUsViewModel)
        {
            var contact = _mapper.Map<ContactUs>(contactUsViewModel);
            if (contact == null)
                throw new ArgumentNullException("Model is null or empty");
            _contactUsService.Create(contact);
            return RedirectToAction("Index",routeValues:new { message=Messages.HelpDesk });
        }

        [NoTrailingSlash]
        [OutputCache(CacheProfile = CacheProfileName.RobotsText)]
        [Route("robots.txt", Name = HomeControllerRoute.GetRobotsText)]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("user-agent: *");
            stringBuilder.AppendLine("disallow: /error/");
            stringBuilder.AppendLine("allow: /error/foo");
            stringBuilder.Append("sitemap: ");
            stringBuilder.AppendLine(this.Url.RouteUrl("GetSitemapXml", null, this.Request.Url.Scheme).TrimEnd('/'));

            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }

        [Route("sitemap.xml", Name = "GetSitemapXml"), OutputCache(Duration = 86400)]
        public ContentResult SitemapXml()
        {
            return null;
        }
    }
}