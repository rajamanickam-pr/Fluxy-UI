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
using System.Diagnostics;
using Fluxy.Services.Manifest;
using Fluxy.Services.Robot;
using System.Net;
using Fluxy.Services.Sitemap;
using Fluxy.Services.OpenSearch;
using Fluxy.Services.BrowserConfig;
using Fluxy.Services.Feed;
using Fluxy.Data.ExtentedDTO;
using System.Web.Hosting;

namespace Fluxy.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBannerDetailsService _bannerDetailsService;
        private readonly IMapper _mapper;
        private readonly IVideoAttributesService _videoAttributesService;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IUserProfileService _userProfileService;
        private readonly IContactUsService _contactUsService;
        private readonly IManifestService _manifestService;
        private readonly IRobotsService _robotsService;
        private readonly ISitemapService _sitemapService;
        private readonly IOpenSearchService _openSearchService;
        private readonly IBrowserConfigService _browserConfigService;
        private readonly IFeedService _feedService;


        public HomeController(IRobotsService robotsService,
            IManifestService manifestService,
            IContactUsService contactUsService,
            IUserSettingsService userSettingsService,
            IUserProfileService userProfileService,
            ILogService logService, IMapper mapper,
            IVideoAttributesService videoAttributesService,
            IBannerDetailsService bannerDetailsService,
            ISitemapService sitemapService,
            IOpenSearchService openSearchService,
            IBrowserConfigService browserConfigService,
            IFeedService feedService)
            : base(logService, mapper)
        {
            _videoAttributesService = videoAttributesService;
            _mapper = mapper;
            _userSettingsService = userSettingsService;
            _userProfileService = userProfileService;
            _bannerDetailsService = bannerDetailsService;
            _contactUsService = contactUsService;
            _manifestService = manifestService;
            _robotsService = robotsService;
            _sitemapService = sitemapService;
            _openSearchService = openSearchService;
            _browserConfigService = browserConfigService;
            _feedService = feedService;
        }

        [Route("", Name = HomeControllerRoute.GetIndex)]
        public async Task<ActionResult> Index(string message)
        {
            var isAdultContent = false;
            IEnumerable<VideoAttributesExtend> recentlyAdded;
            IEnumerable<VideoAttributesExtend> popularVideos;
            IEnumerable<VideoAttributesExtend> generalVideos;
            IEnumerable<VideoAttributesExtend> infoVideos;
            IEnumerable<VideoAttributesExtend> entertainmentVideos;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var userSettings = await _userSettingsService.GetSingleAsync(i => i.UserId == userId);
                var userProfile = await _userProfileService.GetSingleAsync(i => i.UserId == userId);
                if (userSettings != null)
                {
                    if (userProfile?.Age > 18)
                    {
                        isAdultContent = userSettings.CanISeeEPContent;
                    }
                }
            }

            if (isAdultContent)
            {
                recentlyAdded = _videoAttributesService.GetList(i => i.IsPublicVideo).OrderByDescending(i => i.CreatedDate).Take(9);
                popularVideos = _videoAttributesService.GetList(i => i.IsPublicVideo).OrderByDescending(i => i.ViewCount).Take(9);
                generalVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("People & Blogs") && i.IsPublicVideo).OrderByDescending(i => i.ViewCount).Take(9);
                infoVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Education") && i.IsPublicVideo == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
                entertainmentVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Entertainment") && i.IsPublicVideo == isAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
            }
            else
            {
                recentlyAdded = _videoAttributesService.GetList(i => i.IsPublicVideo && !i.IsAdultContent).OrderByDescending(i => i.CreatedDate).Take(9);
                popularVideos = _videoAttributesService.GetList(i => i.IsPublicVideo && !i.IsAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
                generalVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("People & Blogs") && i.IsPublicVideo && !i.IsAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
                infoVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Education") && i.IsPublicVideo == isAdultContent && !i.IsAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
                entertainmentVideos = _videoAttributesService.GetList(i => i.Category.Name.Contains("Entertainment") && i.IsPublicVideo == isAdultContent && !i.IsAdultContent).OrderByDescending(i => i.ViewCount).Take(9);
            }

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

            return View(HomeControllerAction.Index, homeViewModel);
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

        [HttpGet]
        [Route("SiteSearch", Name = HomeControllerRoute.GetSiteSearch)]
        public virtual ActionResult SiteSearch()
        {
            return View(HomeControllerAction.SiteSearch, null);
        }

        [HttpPost]
        [Route("SiteSearch", Name = HomeControllerRoute.PostSiteSearch)]
        public async Task<ActionResult> SiteSearch(FormCollection data)
        {
            var searchText = data["searchText"].ToString().ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var videos = await _videoAttributesService.GetListAsync(i => i.Title.ToLower().Contains(searchText));
                var searchVideos = _mapper.Map<List<VideoAttributesViewModel>>(videos.Take(12));
                return View(HomeControllerAction.SiteSearch, searchVideos);
            }
            else
            {
                Danger("Text should not be empty.");
                return View();
            }
        }

        [Route("helpdesk", Name = HomeControllerRoute.GetHelpDesk)]
        public virtual ActionResult HelpDesk()
        {
            return View(HomeControllerAction.HelpDesk);
        }

        [HttpPost]
        [Route("helpdesk", Name = HomeControllerRoute.PostHelpDesk)]
        public virtual ActionResult HelpDesk(ContactUsViewModel contactUsViewModel)
        {
            var contact = _mapper.Map<ContactUs>(contactUsViewModel);
            if (contact == null)
                throw new ArgumentNullException("Model is null or empty");
            _contactUsService.Create(contact);
            return RedirectToAction("Index", routeValues: new { message = Messages.HelpDesk });
        }

        [Route("search", Name = HomeControllerRoute.GetSearch)]
        public ActionResult Search(string query)
        {
            // You can implement a proper search function here and add a Search.cshtml page.
            // return this.View(HomeControllerAction.Search);

            // Or you could use Google Custom Search (https://cse.google.co.uk/cse) to index your site and display your 
            // search results in your own page.

            // For simplicity we are just assuming your site is indexed on Google and redirecting to it.
            return this.Redirect(string.Format(
                "https://www.google.co.uk/?q=site:{0} {1}",
                this.Url.AbsoluteRouteUrl(HomeControllerRoute.GetIndex),
                query));
        }

        [OutputCache(CacheProfile = CacheProfileName.Feed)]
        [Route("feed", Name = HomeControllerRoute.GetFeed)]
        public async Task<ActionResult> Feed()
        {
            // A CancellationToken signifying if the request is cancelled. See
            // http://www.davepaquette.com/archive/2015/07/19/cancelling-long-running-queries-in-asp-net-mvc-and-web-api.aspx
            CancellationToken cancellationToken = this.Response.ClientDisconnectedToken;
            return new AtomActionResult(await this._feedService.GetFeed(cancellationToken));
        }

        [NoTrailingSlash]
        [OutputCache(CacheProfile = CacheProfileName.BrowserConfigXml)]
        [Route("browserconfig.xml", Name = HomeControllerRoute.GetBrowserConfigXml)]
        public ContentResult BrowserConfigXml()
        {
            Trace.WriteLine(string.Format(
                "browserconfig.xml requested. User Agent:<{0}>.",
                this.Request.Headers.Get("User-Agent")));
            string content = this._browserConfigService.GetBrowserConfigXml();
            return this.Content(content, ContentType.Xml, Encoding.UTF8);
        }

        [NoTrailingSlash]
        [OutputCache(CacheProfile = CacheProfileName.ManifestJson)]
        [Route("manifest.json", Name = HomeControllerRoute.GetManifestJson)]
        public ContentResult ManifestJson()
        {
            Trace.WriteLine(string.Format(
                "manifest.jsonrequested. User Agent:<{0}>.",
                this.Request.Headers.Get("User-Agent")));
            string content = this._manifestService.GetManifestJson();
            return this.Content(content, ContentType.Json, Encoding.UTF8);
        }

        [NoTrailingSlash]
        [OutputCache(CacheProfile = CacheProfileName.OpenSearchXml)]
        [Route("opensearch.xml", Name = HomeControllerRoute.GetOpenSearchXml)]
        public ContentResult OpenSearchXml()
        {
            Trace.WriteLine(string.Format(
                "opensearch.xml requested. User Agent:<{0}>.",
                this.Request.Headers.Get("User-Agent")));
            string content = this._openSearchService.GetOpenSearchXml();
            return this.Content(content, ContentType.Xml, Encoding.UTF8);
        }

        [NoTrailingSlash]
        [OutputCache(CacheProfile = CacheProfileName.RobotsText)]
        [Route("robots.txt", Name = HomeControllerRoute.GetRobotsText)]
        public ContentResult RobotsText()
        {
            Trace.WriteLine(string.Format(
               "robots.txt requested. User Agent:<{0}>.",
               this.Request.Headers.Get("User-Agent")));
            string content = this._robotsService.GetRobotsText();
            return this.Content(content, ContentType.Text, Encoding.UTF8);
        }

        [NoTrailingSlash]
        [Route("sitemap.xml", Name = HomeControllerRoute.GetSitemapXml), OutputCache(Duration = 86400)]
        public ActionResult SitemapXml(int? index = null)
        {
            //string content = this._sitemapService.GetSitemapXml(index);

            //if (content == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Sitemap index is out of range.");
            //}
            //return this.Content(content, ContentType.Xml, Encoding.UTF8);
            var path = HostingEnvironment.MapPath(Url.Content("~/App_Data/Sitemap/Sitemap.xml"));
            string content = System.IO.File.ReadAllText(path);
            return this.Content(content, ContentType.Xml, Encoding.UTF8);
        }
    }
}